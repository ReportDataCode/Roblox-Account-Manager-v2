﻿using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable CS0618 // stupid parameter warnings

namespace RBX_Alt_Manager
{
    public partial class AccountManager : Form
    {
        public static List<RbxProcess> RbxProcesses = new List<RbxProcess>();
        public static List<Account> AccountsList = new List<Account>();
        public static Account SelectedAccount;
        public static RestClient mainclient;
        public static RestClient apiclient;
        public static RestClient client;
        public static RestClient econclient;
        public static RestClient AccountClient;
        public static string CurrentVersion;
        public static string CurrentPlaceId;
        private AccountAdder aaform;
        private ArgumentsForm afform;
        private ServerList ServerListForm;
        private AccountUtils UtilsForm;
        private static DateTime startTime = DateTime.Now;
        public static bool IsTeleport = false;
        public static bool UseOldJoin = false;
        public ListViewItem SelectedAccountItem;
        // public Account SelectedAccount;
        private ListViewItem LastViewItem;
        private string RbxJoinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rbx-join.exe");
        private string CommandValue;
        private RegistryKey ManagerKey;
        private string ManagerKeyName = "RbxAccountManager";
        private ListViewItem DraggingItem;
        private DateTime DragTime = DateTime.MinValue;

        private delegate void SafeCallDelegateAccount(Account account);
        private delegate void SafeCallDelegateGroup(string Group, ListViewItem Item = null);
        private delegate void SafeCallDelegateRemoveAt(int Index);
        private delegate int SafeCallDelegateInvite(object Item);

        public AccountManager()
        {
            InitializeComponent();
        }

        private static string SaveFilePath = Path.Combine(Environment.CurrentDirectory, "AccountData.json");

        private void LoadAccounts()
        {
            if (File.Exists(SaveFilePath))
            {
                try
                {
                    AccountsList = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(SaveFilePath));

                    foreach (Account acc in AccountsList)
                        AddAccountToList(acc);
                }
                catch
                {
                    File.WriteAllText(SaveFilePath + ".bak", File.ReadAllText(SaveFilePath));
                }
            }
        }

        public static void SaveAccounts()
        {
            if ((DateTime.Now - startTime).Seconds < 5 || AccountsList.Count == 0) return;

            string OldInfo = File.Exists(SaveFilePath) ? File.ReadAllText(SaveFilePath) : "";
            string SaveData = JsonConvert.SerializeObject(AccountsList);
            int OldSize = Encoding.Unicode.GetByteCount(OldInfo);
            int NewSize = Encoding.Unicode.GetByteCount(SaveData);

            FileInfo OldFile = new FileInfo(SaveFilePath);

            if (OldFile.Exists && NewSize < OldSize || (OldFile.Exists && (DateTime.Now - OldFile.LastWriteTime).TotalHours > 36))
                File.WriteAllText(SaveFilePath + ".backup", OldInfo);

            File.WriteAllText(SaveFilePath, SaveData);
        }

        public static long GetUserID(string Username)
        {
            RestRequest request = new RestRequest("users/get-by-username?username=" + Username, Method.GET);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = response = apiclient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                UsernameReponse userData = JsonConvert.DeserializeObject<UsernameReponse>(response.Content);

                return userData.Id;
            }

            return -1;
        }

        public void AddAccountToList(Account account)
        {
            string Name = account.Username + " " + account.Alias;

            if (AccountsView.InvokeRequired)
            {
                var addItem = new SafeCallDelegateAccount(AddAccountToList);
                AccountsView.Invoke(addItem, new object[] { account });
            }
            else
            {
                ListViewItem Item = new ListViewItem(new string[] { account.Username, account.Alias, account.Description.Replace("\n", " "), account.Username });

                AccountsView.Items.Add(Item);

                if (!string.IsNullOrEmpty(account.Group)) AddGroupToList(account.Group, Item);
            }
        }

        public void AddGroupToList(string GroupName, ListViewItem Item = null)
        {
            bool CreateGroup = true;
            ListViewGroup GroupItem = null;

            foreach (ListViewGroup g in AccountsView.Groups)
            {
                if (g.Header == GroupName)
                {
                    GroupItem = g;
                    CreateGroup = false;
                }
            }

            if (GroupItem == null && !string.IsNullOrEmpty(GroupName))
                GroupItem = new ListViewGroup(GroupName);

            if (GroupItem != null) AccountsView.ShowGroups = true;
            if (CreateGroup && GroupItem != null) AccountsView.Groups.Add(GroupItem);

            if (Item != null)
                Item.Group = GroupItem;
            else if (SelectedAccount != null && SelectedAccountItem != null)
            {
                SelectedAccount.Group = GroupName;
                SelectedAccountItem.Group = GroupItem;
                AccountsList.Remove(SelectedAccount);
                AccountsList.Insert(AccountsList.Count, SelectedAccount); // move to end of account list
                SaveAccounts();
            }
        }

        public static void AddAccount(string SecurityToken, string UserData)
        {
            Account account = new Account();

            string res = account.Validate(SecurityToken, UserData);

            if (res == "Success")
            {
                Account exists = AccountsList.FirstOrDefault(acc => acc.UserID == account.UserID);

                if (exists != null)
                    exists.SecurityToken = account.SecurityToken;
                else
                {
                    AccountsList.Add(account);
                    Program.MainForm.AddAccountToList(account);
                }

                SaveAccounts();
            }
            else MessageBox.Show(res);
        }

        public static string ShowDialog(string text, string caption) //tbh pasted from stackoverflow
        {
            Form prompt = new Form()
            {
                Width = 270,
                Height = 125,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 15, Top = 10, Text = text };
            TextBox textBox = new TextBox() { Left = 15, Top = 25, Width = 220 };
            Button confirmation = new Button() { Text = "OK", Left = 15, Width = 100, Top = 50, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            if (Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName
                .Contains(Path.GetTempPath()))
            {
                int Stupid = 1337;
                MessageBox.Show("bro extract the files, don't run it in winrar");
                Environment.Exit(Stupid);
            }

            CommandValue = RbxJoinPath + " \"%1\"";

            if (!File.Exists(RbxJoinPath))
            {
                MessageBox.Show("Failed to find rbx-join executable", "Roblox Account Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
            }

            if (!File.Exists("dev.mode"))
            {
                AccountsStrip.Items.Remove(getAuthenticationTicketToolStripMenuItem);
                AccountsStrip.Items.Remove(copyRbxplayerLinkToolStripMenuItem);
                AccountsStrip.Items.Remove(copySecurityTokenToolStripMenuItem);
            }

            if (File.Exists("AU.exe"))
            {
                if (File.Exists("Auto Update.exe"))
                    File.Delete("Auto Update.exe");

                File.Copy("AU.exe", "Auto Update.exe");
                File.Delete("AU.exe");
            }

            ArgumentsB.Visible = false; // has no use right now
            JoinServer.Size = new Size(197, 23);

            RegistryKey MainKey = Registry.ClassesRoot.OpenSubKey("rbx-join");
            RegistryKey CommandKey = Registry.ClassesRoot.OpenSubKey(@"rbx-join\shell\open\command");

            // if (MainKey == null || CommandKey == null || (string)CommandKey.GetValue("") != CommandValue)
            // MessageBox.Show("The rbx-join protocol is not setup, run RegisterRbxJoinProtocol.exe to set it up", "rbx-join", MessageBoxButtons.OK, MessageBoxIcon.Information); // kinda annoying ngl if you want rbx-join then yea u know how

            RegistryKey HandleKey = Registry.CurrentUser.OpenSubKey(@"Software\Sysinternals\Handle");

            if (HandleKey == null || HandleKey.GetValue("EulaAccepted") == null || (int)HandleKey.GetValue("EulaAccepted") != 1)
                Process.Start("handle.exe");

            ManagerKey = Registry.CurrentUser.OpenSubKey(ManagerKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (ManagerKey == null)
                ManagerKey = Registry.CurrentUser.CreateSubKey(ManagerKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

            PlaceID.Text = ManagerKey.GetValue("SavedPlaceId", 3016661674).ToString();

            SetupNamedPipe();

            aaform = new AccountAdder();
            afform = new ArgumentsForm();
            ServerListForm = new ServerList();
            UtilsForm = new AccountUtils();

            AccountsView.Items.Clear();

            // RobloxProcessTimer.Start();

            mainclient = new RestClient("https://www.roblox.com/");
            mainclient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

            apiclient = new RestClient("https://api.roblox.com/");
            apiclient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

            client = new RestClient("https://auth.roblox.com/");
            client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

            econclient = new RestClient("https://economy.roblox.com/");
            econclient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

            AccountClient = new RestClient("https://accountsettings.roblox.com/");
            AccountClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

            WebClient WC = new WebClient();
            string VersionJSON = WC.DownloadString("https://clientsettings.roblox.com/v1/client-version/WindowsPlayer");
            JObject j = JObject.Parse(VersionJSON);
            if (j.TryGetValue("clientVersionUpload", out JToken token))
                CurrentVersion = token.Value<string>();

            PlaceID_TextChanged(PlaceID, new EventArgs());

            Task.Run(() =>
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    string version = fvi.FileVersion.Substring(0, 3);
                    WC.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";
                    string Releases = WC.DownloadString("https://api.github.com/repos/ic3w0lf22/Roblox-Account-Manager/releases/latest");
                    Match match = Regex.Match(Releases, @"""tag_name"":\s*""?([^""]+)");

                    if (match.Success && match.Groups[1].Value != version)
                    {
                        DialogResult result = MessageBox.Show("An update is available, click yes to run the auto updater or no to be redirected to the download page.", "Roblox Account Manager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string AFN = Path.Combine(Directory.GetCurrentDirectory(), "Auto Update.exe");

                            if (File.Exists(AFN))
                            {
                                Process.Start(AFN);
                                Environment.Exit(1);
                            }
                            else
                            {
                                MessageBox.Show("You do not have the auto updater downloaded, go to the github page and download the latest release.");
                                Process.Start("https://github.com/ic3w0lf22/Roblox-Account-Manager/releases");
                            }
                        }
                        else if (result == DialogResult.No)
                            Process.Start("https://github.com/ic3w0lf22/Roblox-Account-Manager/releases");
                    }
                }
                catch { }
            });
        }

        private void AccountManager_Shown(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            DialogResult result = MessageBox.Show($"Are you sure you want to remove {SelectedAccount.Username}?", "Remove Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                AccountsView.Items.Remove(SelectedAccountItem);

                AccountsList.RemoveAll(x => x == SelectedAccount);
                SaveAccounts();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (aaform != null && aaform.Visible)
                aaform.HideForm();

            aaform.BrowserMode = false;
            aaform.ShowForm();
        }

        private void AccountsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LastViewItem != null)
            {
                LastViewItem.ForeColor = Color.Black;
                LastViewItem.BackColor = Color.Gray;
            }

            if (AccountsView.SelectedItems.Count != 1)
            {
                SelectedAccountItem = null;
                return;
            }

            SelectedAccountItem = AccountsView.SelectedItems[0];
            SelectedAccountItem.ForeColor = Color.White;
            SelectedAccountItem.BackColor = Color.DodgerBlue;
            LastViewItem = SelectedAccountItem;

            AccountsView.HideSelection = true;

            try
            {
                string Item = SelectedAccountItem.SubItems[3].Text;
                Account account = AccountsList.FirstOrDefault(x => x.Username == Item);

                if (account != null)
                {
                    SelectedAccount = account;
                    Alias.Text = account.Alias;
                    DescriptionBox.Text = account.Description;
                }
            }
            catch { }
        }

        private void SetAlias_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            SelectedAccount.Alias = Alias.Text;
            SelectedAccountItem.SubItems[3].Text = SelectedAccount.Username;
            SelectedAccountItem.SubItems[1].Text = SelectedAccount.Alias;
        }

        private void SetDescription_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            SelectedAccount.Description = DescriptionBox.Text;
            SelectedAccountItem.SubItems[2].Text = SelectedAccount.Description.Replace("\n", "");
        }

        private void JoinServer_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            bool VIPServer = JobID.TextLength > 4 ? JobID.Text.Substring(0, 4) == "VIP:" : false;

            string res = SelectedAccount.JoinServer(Convert.ToInt64(PlaceID.Text), VIPServer ? JobID.Text.Substring(4) : JobID.Text, false, VIPServer);

            if (!res.Contains("Success"))
                MessageBox.Show(res);
        }

        private void Follow_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            long UserId = GetUserID(UserID.Text);

            if (UserId < 0)
            {
                MessageBox.Show("Failed to get UserId");
                return;
            }

            string res = SelectedAccount.JoinServer(UserId, "", true);

            if (!res.Contains("Success"))
                MessageBox.Show(res);
        }

        private void PlaceID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void OpenBrowser_Click(object sender, EventArgs e) // not used i forgot this was here
        {
            if (1 == 1 || SelectedAccount == null) return;

            RestRequest tokenrequest = new RestRequest("v1/authentication-ticket/", Method.POST);

            tokenrequest.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            tokenrequest.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");

            IRestResponse response = client.Execute(tokenrequest);
            Parameter result = response.Headers.FirstOrDefault(x => x.Name == "x-csrf-token");

            string Token = "";

            if (result != null)
                Token = (string)result.Value;
            else
                return;

            if (string.IsNullOrEmpty(Token) || result == null)
                return;

            RestRequest request = new RestRequest("v1/purchases/products/502391436", Method.POST);
            request.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            request.AddHeader("X-CSRF-TOKEN", Token);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", "{\"expectedCurrency\":1,\"expectedPrice\":350,\"expectedSellerId\":875316944}", ParameterType.RequestBody);
            request.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");
            response = econclient.Execute(request);
            MessageBox.Show(response.Content);
        }

        private void ServerList_Click(object sender, EventArgs e)
        {
            if (ServerListForm.Visible)
                ServerListForm.BringToFront();
            else
                ServerListForm.Show();
        }

        private void HideUsernamesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in AccountsView.Items)
            {
                Account account = AccountsList.FirstOrDefault(x => Item.SubItems[3].Text.Length >= x.Username.Length && x.Username == Item.SubItems[3].Text.Substring(0, x.Username.Length));

                Item.Text = HideUsernamesCheckbox.Checked ? Regex.Replace(account.Username, ".", "*") : account.Username;
            }
        }

        private void addAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aaform != null && aaform.Visible)
                aaform.HideForm();

            aaform.ShowForm();
        }

        private void removeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            DialogResult result = MessageBox.Show("Are you sure?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                AccountsView.Items.Remove(SelectedAccountItem);
                AccountsList.RemoveAll(x => x == SelectedAccount);

                SaveAccounts();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Roblox Account Manager created by ic3w0lf under the GNU GPLv3 license.", "Roblox Account Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int AddInviteLinkItem(object Item)
        {
            if (Item == null || string.IsNullOrEmpty((string)Item)) return -1;

            if (InviteLinks.InvokeRequired)
            {
                SafeCallDelegateInvite addItem = new SafeCallDelegateInvite(AddInviteLinkItem);
                return (int)InviteLinks.Invoke(addItem, new object[] { Item });
            }
            else
                return InviteLinks.Items.Add(Item);
        }

        private void RemoveInviteLinkItem(int Index)
        {
            if (InviteLinks.InvokeRequired)
            {
                SafeCallDelegateRemoveAt removeAt = new SafeCallDelegateRemoveAt(RemoveInviteLinkItem);
                InviteLinks.Invoke(removeAt, new object[] { Index });
            }
            else
                InviteLinks.Items.RemoveAt(Index);
        }

        // some code might be scuffed cuz visual studio deleted 2 days worth of progress and got it off of dnspy

        private void RobloxProcessTimer_Tick(object sender, EventArgs e)
        {
            List<RbxProcess> Processes = RbxProcesses.ToList();

            foreach (Process p in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                if (!Processes.Any(x => x.RobloxProcess.MainWindowHandle == p.MainWindowHandle))
                {
                    RbxProcess rbx = new RbxProcess(p);
                    RbxProcesses.Add(rbx);

                    Task.Run(() =>
                    {
                        Task.Delay(1000);
                        DateTime setupTime = DateTime.Now;
                        rbx.Setup();

                        do
                            Task.Delay(500);
                        while (string.IsNullOrEmpty(rbx.UserName) && (DateTime.Now - setupTime).TotalSeconds < 5.0);

                        try
                        { // this is stupid but error spam is also stupid and so am i
                            if (rbx.Working && p.Responding)
                            {
                                p.EnableRaisingEvents = true;
                                p.Exited += new EventHandler(RobloxProcess_Exited);
                                rbx.Index = AddInviteLinkItem(rbx.UserName);
                            }
                            else
                                RbxProcesses.Remove(rbx);
                        }
                        catch { RbxProcesses.Remove(rbx); }
                    });
                }
            }
        }

        private void RobloxProcess_Exited(object sender, EventArgs e)
        {
            Process Exited = (Process)sender;

            RbxProcess process = RbxProcesses.FirstOrDefault(x => x.RobloxProcess == Exited);

            if (process == null) return;

            RbxProcesses.Remove(process);

            for (int Index = 0; Index < InviteLinks.Items.Count; Index++)
            {
                if ((string)InviteLinks.Items[Index] == process.UserName)
                {
                    RemoveInviteLinkItem(Index);
                    break;
                }
            }
        }

        private void SetupNamedPipe()
        {
            Task.Factory.StartNew(() =>
            {
                NamedPipeServerStream pipe = new NamedPipeServerStream("AccountManagerPipe", PipeDirection.InOut, -1, PipeTransmissionMode.Message);

                while (true)
                {
                    pipe.WaitForConnection();
                    byte[] messageBytes = ReadMessage(pipe);
                    string line = Encoding.UTF8.GetString(messageBytes);

                    if (string.IsNullOrEmpty(line)) continue;

                    if (line == "acclist")
                    {
                        string AccountString = HideUsernamesCheckbox.Checked ? "hidden\n" : "";

                        foreach (Account acc in AccountsList)
                            AccountString = AccountString + acc.Username + "::" + acc.Alias + "\n";

                        if (AccountString.Length > 1)
                            AccountString = AccountString.Substring(0, AccountString.Length - 1);

                        byte[] response = Encoding.UTF8.GetBytes(AccountString);
                        pipe.Write(response, 0, response.Length);
                    }
                    else if (line.Substring(0, 4) == "play")
                    {
#if DEBUG
                        Console.WriteLine(line);
#endif
                        Match match = Regex.Match(line, "play\\-(\\w+)\\-(\\d+)\\-?(\\w+-\\w+-\\w+-\\w+-\\w+)?");

                        if (match.Success)
                        {
                            string AccountName = match.Groups[1].Value;
                            long PlaceId = Convert.ToInt64(match.Groups[2].Value);
                            string JobId = (match.Groups.Count == 4) ? match.Groups[3].Value : "";

                            Account account = AccountsList.FirstOrDefault((Account x) => AccountName.Length >= x.Username.Length && x.Username == AccountName.Substring(0, x.Username.Length));
                            account.JoinServer(PlaceId, JobId, false);
                        }
                    }

                    pipe.Disconnect();
                }
            });
        }

        private static byte[] ReadMessage(PipeStream pipe)
        {
            byte[] buffer = new byte[1024];
            byte[] result;
            using (MemoryStream ms = new MemoryStream())
            {
                do
                {
                    int readBytes = pipe.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, readBytes);
                }
                while (!pipe.IsMessageComplete);
                result = ms.ToArray();
            }
            return result;
        }

        private void InviteLinks_TextUpdate(object sender, EventArgs e)
        {
            InviteLinks.Text = "Copy Invite Link";
        }

        private void InviteLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InviteLinks.SelectedIndex < 0 || InviteLinks.SelectedItem == null) return;

            RbxProcess rbx = RbxProcesses.FirstOrDefault(x => x.UserName == (string)InviteLinks.SelectedItem);

            if (rbx != null)
            {
                Clipboard.SetText(string.Format("<rbx-join://{0}/{1}>", rbx.PlaceId, rbx.JobId));
                MessageBox.Show("Copied to Clipboard!");
            }
        }

        private void AccountManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ManagerKey == null || PlaceID == null || string.IsNullOrEmpty(PlaceID.Text)) return;

            ManagerKey.SetValue("SavedPlaceId", PlaceID.Text);
        }

        private void BrowserButton_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null)
            {
                MessageBox.Show("No Account Selected!");
                return;
            }

            UtilsForm.Show();

            /*if (aaform != null && aaform.Visible)
                aaform.HideForm();

            aaform.ShowForm();
            aaform.BrowserMode = true;
            CefSharp.Cookie seccookie = new CefSharp.Cookie();
            seccookie.Name = ".ROBLOSECURITY";
            seccookie.Value = SelectedAccount.SecurityToken;
            /*CefSharp.Cookie idcookie = new CefSharp.Cookie();
            idcookie.Name = "RBXAppDeviceIdentifier";
            idcookie.Value = "AppDeviceIdentifier=ROBLOX UWP";*/
            // CefSharp.Cef.GetGlobalCookieManager().SetCookie("https://www.roblox.com", seccookie);
            // CefSharp.Cef.GetGlobalCookieManager().SetCookie("https://www.roblox.com", idcookie);
            // aaform.chromeBrowser.Load("https://www.roblox.com/home");
        }

        private void reAuthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            if (aaform != null && aaform.Visible)
                aaform.HideForm();

            aaform.BrowserMode = false;
            aaform.ShowForm();

            aaform.SetUsername = SelectedAccount.Username;
        }

        private void AccountsView_MouseDown(object sender, MouseEventArgs e)
        {
            if (AccountsView.Groups.Count > 0) return;

            DraggingItem = AccountsView.GetItemAt(e.X, e.Y);
            DragTime = DateTime.Now;
        }

        private void AccountsView_MouseMove(object sender, MouseEventArgs e)
        {
            if (DraggingItem == null || (DateTime.Now - DragTime).TotalMilliseconds < 120) return;

            Cursor = Cursors.Hand;
        }

        private void AccountsView_MouseUp(object sender, MouseEventArgs e)
        {
            if ((DateTime.Now - DragTime).TotalMilliseconds < 120) DraggingItem = null;

            Cursor = Cursors.Default;

            if (DraggingItem == null) return;

            ListViewItem HoveringItem = AccountsView.GetItemAt(0, e.Y);

            if (HoveringItem == null) return;

            Rectangle rc = HoveringItem.GetBounds(ItemBoundsPortion.Entire);

            bool InsertBefore = (e.Y < rc.Top + (rc.Height / 2));

            if (DraggingItem != HoveringItem)
            {
                string Item = DraggingItem.SubItems[3].Text;
                Account account = AccountsList.FirstOrDefault(x => Item.Length >= x.Username.Length && x.Username == Item.Substring(0, x.Username.Length));

                if (account == null) { MessageBox.Show("Something went wrong!", "Roblox Account Manager", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (InsertBefore)
                {
                    AccountsView.Items.Remove(DraggingItem);
                    AccountsView.Items.Insert(HoveringItem.Index, DraggingItem);

                    AccountsList.Remove(account);
                    AccountsList.Insert(HoveringItem.Index - 1, account);
                }
                else
                {
                    AccountsView.Items.Remove(DraggingItem);
                    AccountsView.Items.Insert(HoveringItem.Index + 1, DraggingItem);

                    AccountsList.Remove(account);
                    AccountsList.Insert(HoveringItem.Index, account);
                }

                DraggingItem = null;

                SaveAccounts();
            }
        }

        private void getAuthenticationTicketToolStripMenuItem_Click(object sender, EventArgs e) // shouldn't be available to public releases
        {
            if (SelectedAccount == null) return;

            RestRequest request = new RestRequest("v1/authentication-ticket/", Method.POST);

            request.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            request.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");

            IRestResponse response = client.Execute(request);
            Parameter result = response.Headers.FirstOrDefault(x => x.Name == "x-csrf-token");

            string Token = "";

            if (result != null)
                Token = (string)result.Value;
            else
                return;

            if (string.IsNullOrEmpty(Token) || result == null)
                return;

            request = new RestRequest("/v1/authentication-ticket/", Method.POST);
            request.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            request.AddHeader("X-CSRF-TOKEN", Token);
            request.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");
            response = client.Execute(request);

            Parameter Ticket = response.Headers.FirstOrDefault(x => x.Name == "rbx-authentication-ticket");

            if (Ticket != null)
                Clipboard.SetText((string)Ticket.Value);
        }

        private void copyRbxplayerLinkToolStripMenuItem_Click(object sender, EventArgs e) // shouldn't be available to public releases
        {
            if (SelectedAccount == null) return;

            RestRequest request = new RestRequest("v1/authentication-ticket/", Method.POST);

            request.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            request.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");

            IRestResponse response = client.Execute(request);
            Parameter result = response.Headers.FirstOrDefault(x => x.Name == "x-csrf-token");

            string Token = "";

            if (result != null)
                Token = (string)result.Value;
            else
                return;

            if (string.IsNullOrEmpty(Token) || result == null)
                return;

            request = new RestRequest("/v1/authentication-ticket/", Method.POST);
            request.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            request.AddHeader("X-CSRF-TOKEN", Token);
            request.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");
            response = client.Execute(request);

            Parameter Ticket = response.Headers.FirstOrDefault(x => x.Name == "rbx-authentication-ticket");

            if (Ticket != null)
            {
                Token = (string)Ticket.Value;
                bool HasJobId = string.IsNullOrEmpty(JobID.Text);
                double LaunchTime = Math.Floor((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds * 1000);

                Random r = new Random();
                Clipboard.SetText(string.Format("<roblox-player://1/1+launchmode:play+gameinfo:{0}+launchtime:{4}+browsertrackerid:{5}+placelauncherurl:https://assetgame.roblox.com/game/PlaceLauncher.ashx?request=RequestGame{3}&placeId={1}{2}+robloxLocale:en_us+gameLocale:en_us>", Token, PlaceID.Text, HasJobId ? "" : ("&gameId=" + JobID.Text), HasJobId ? "" : "Job", LaunchTime, r.Next(500000, 600000).ToString() + r.Next(10000, 90000).ToString()));
            }
        }

        private void ArgumentsB_Click(object sender, EventArgs e)
        {
            if (afform != null && afform.Visible)
                afform.HideForm();

            afform.ShowForm();
        }

        private DateTime LastRefresh = DateTime.MinValue;

        private void RefreshLinks_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now - LastRefresh).TotalSeconds < 3) return; // prevent spam clicking button . . .

            LastRefresh = DateTime.Now;
            RobloxProcessTimer_Tick(sender, e); // lazy
        }

        private void copySecurityTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            Clipboard.SetText(SelectedAccount.SecurityToken);
        }

        private void copyUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            Clipboard.SetText(SelectedAccount.Username);
        }

        private void PlaceID_TextChanged(object sender, EventArgs e)
        {
            CurrentPlaceId = PlaceID.Text;

            if (PlaceTimer.Enabled) PlaceTimer.Stop();

            PlaceTimer.Start();
        }

        private void PlaceTimer_Tick(object sender, EventArgs e)
        {
            if (apiclient == null) return;

            PlaceTimer.Stop();

            RestRequest request = new RestRequest("Marketplace/ProductInfo?assetId=" + PlaceID.Text, Method.GET);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = response = apiclient.Execute(request);

            if (response.IsSuccessful && response.StatusCode == HttpStatusCode.OK)
            {
                ProductInfo placeInfo = JsonConvert.DeserializeObject<ProductInfo>(response.Content);

                CurrentPlace.Text = placeInfo.Name;
            }
        }

        private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string GroupName = ShowDialog("Group Name", "Move Account to Group");

            if (string.IsNullOrEmpty(GroupName)) return;

            bool CreateGroup = true;

            if (AccountsView.Groups.Count == 0)
            {
                DialogResult res = MessageBox.Show("Creating groups prevents accounts from being moved! Continue?", "Groups", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.No)
                    CreateGroup = false;
            }

            if (CreateGroup)
                AddGroupToList(GroupName);
        }

        private void MoveAccounts(ListViewGroup Group1, ListViewGroup Group2 = null)
        {
            List<Account> AccountsToMove = new List<Account>();
            int Index = -1;

            foreach (Account acc in AccountsList)
            {
                if (acc.Group == Group1.Header)
                    AccountsToMove.Add(acc);

                if (Group2 != null && acc.Group == Group2.Header)
                    Index = AccountsList.IndexOf(acc);
            }

            Index -= AccountsToMove.Count; if (Index < 0) Index = 0;

            AccountsList.RemoveAll(x => AccountsToMove.Contains(x));
            AccountsList.InsertRange(Index, AccountsToMove.ToArray());

            SaveAccounts();
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAccountItem != null && SelectedAccountItem.Group != null)
            {
                ListViewGroup Group = SelectedAccountItem.Group;
                int Index = AccountsView.Groups.IndexOf(Group);

                if (Index > 0)
                {
                    List<ListViewGroup> gs = new List<ListViewGroup>();
                    ListViewGroup GroupAbove = null;

                    foreach (ListViewGroup group in AccountsView.Groups)
                    {
                        if (group == Group) continue;

                        gs.Insert(gs.Count, group);
                    }

                    if (Index > 0) GroupAbove = gs[Index - 1];

                    gs.Insert(Index - 1, Group);

                    MoveAccounts(Group, GroupAbove);

                    AccountsView.BeginUpdate();
                    AccountsView.Groups.Clear();
                    AccountsView.Groups.AddRange(gs.ToArray());
                    AccountsView.EndUpdate();
                }
            }
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAccountItem != null && SelectedAccountItem.Group != null)
            {
                ListViewGroup Group = SelectedAccountItem.Group;
                int Index = AccountsView.Groups.IndexOf(Group);

                if (Index < AccountsView.Groups.Count - 1)
                {
                    List<ListViewGroup> gs = new List<ListViewGroup>();

                    foreach (ListViewGroup group in AccountsView.Groups)
                    {
                        if (group == Group) continue;

                        gs.Insert(gs.Count, group);
                    }

                    gs.Insert(Index + 1, Group);

                    AccountsView.BeginUpdate();
                    AccountsView.Groups.Clear();
                    AccountsView.Groups.AddRange(gs.ToArray());
                    AccountsView.EndUpdate();
                }
            }
        }

        private void CurrentPlace_Click(object sender, EventArgs e)
        {

        }

        private void copyAppLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAccount == null) return;

            RestRequest request = new RestRequest("v1/authentication-ticket/", Method.POST);

            request.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            request.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");

            IRestResponse response = client.Execute(request);
            Parameter result = response.Headers.FirstOrDefault(x => x.Name == "x-csrf-token");

            string Token = "";

            if (result != null)
                Token = (string)result.Value;
            else
                return;

            if (string.IsNullOrEmpty(Token) || result == null)
                return;

            request = new RestRequest("/v1/authentication-ticket/", Method.POST);
            request.AddCookie(".ROBLOSECURITY", SelectedAccount.SecurityToken);
            request.AddHeader("X-CSRF-TOKEN", Token);
            request.AddHeader("Referer", "https://www.roblox.com/games/171336322/testing");
            response = client.Execute(request);

            Parameter Ticket = response.Headers.FirstOrDefault(x => x.Name == "rbx-authentication-ticket");

            if (Ticket != null)
            {
                Token = (string)Ticket.Value;
                bool HasJobId = string.IsNullOrEmpty(JobID.Text);
                double LaunchTime = Math.Floor((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds * 1000);

                Random r = new Random();
                Clipboard.SetText(string.Format("<roblox-player://1/1+launchmode:app+gameinfo:{0}+launchtime:{1}+browsertrackerid:{2}+robloxLocale:en_us+gameLocale:en_us>", Token, LaunchTime, r.Next(500000, 600000).ToString() + r.Next(10000, 90000).ToString()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}