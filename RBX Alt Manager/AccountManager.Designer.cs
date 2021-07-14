namespace RBX_Alt_Manager
{
    partial class AccountManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManager));
            this.PlaceID = new System.Windows.Forms.TextBox();
            this.JobID = new System.Windows.Forms.TextBox();
            this.LabelJobID = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.JoinServer = new System.Windows.Forms.Button();
            this.SetDescription = new System.Windows.Forms.Button();
            this.DescriptionBox = new System.Windows.Forms.RichTextBox();
            this.SetAlias = new System.Windows.Forms.Button();
            this.Alias = new System.Windows.Forms.TextBox();
            this.Follow = new System.Windows.Forms.Button();
            this.UserID = new System.Windows.Forms.TextBox();
            this.LabelUserID = new System.Windows.Forms.Label();
            this.ServerList = new System.Windows.Forms.Button();
            this.AccountsView = new System.Windows.Forms.ListView();
            this.AccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AliasColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AccountsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyUsernameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveGroupUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAuthenticationTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySecurityTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRbxplayerLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAppLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideUsernamesCheckbox = new System.Windows.Forms.CheckBox();
            this.InviteLinks = new System.Windows.Forms.ComboBox();
            this.RobloxProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.RefreshTip = new System.Windows.Forms.ToolTip(this.components);
            this.RefreshLinks = new System.Windows.Forms.Button();
            this.BrowserButton = new System.Windows.Forms.Button();
            this.ArgumentsB = new System.Windows.Forms.Button();
            this.CurrentPlace = new System.Windows.Forms.Label();
            this.LabelPlaceID = new System.Windows.Forms.Label();
            this.PlaceTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.AccountsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlaceID
            // 
            this.PlaceID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaceID.BackColor = System.Drawing.Color.Silver;
            this.PlaceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlaceID.Location = new System.Drawing.Point(503, 43);
            this.PlaceID.Name = "PlaceID";
            this.PlaceID.Size = new System.Drawing.Size(84, 20);
            this.PlaceID.TabIndex = 1;
            this.PlaceID.Text = "3016661674";
            this.PlaceID.TextChanged += new System.EventHandler(this.PlaceID_TextChanged);
            this.PlaceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlaceID_KeyPress);
            // 
            // JobID
            // 
            this.JobID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JobID.BackColor = System.Drawing.Color.Silver;
            this.JobID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobID.Location = new System.Drawing.Point(593, 43);
            this.JobID.Name = "JobID";
            this.JobID.Size = new System.Drawing.Size(178, 20);
            this.JobID.TabIndex = 2;
            // 
            // LabelJobID
            // 
            this.LabelJobID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelJobID.AutoSize = true;
            this.LabelJobID.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelJobID.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelJobID.Location = new System.Drawing.Point(590, 27);
            this.LabelJobID.Name = "LabelJobID";
            this.LabelJobID.Size = new System.Drawing.Size(42, 15);
            this.LabelJobID.TabIndex = 4;
            this.LabelJobID.Text = "Job ID";
            // 
            // Add
            // 
            this.Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add.BackColor = System.Drawing.Color.Gray;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.Add.ForeColor = System.Drawing.Color.Black;
            this.Add.Location = new System.Drawing.Point(13, 305);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(95, 23);
            this.Add.TabIndex = 13;
            this.Add.Text = "LOGIN";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Remove
            // 
            this.Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Remove.BackColor = System.Drawing.Color.Gray;
            this.Remove.FlatAppearance.BorderSize = 0;
            this.Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.Remove.ForeColor = System.Drawing.Color.Black;
            this.Remove.Location = new System.Drawing.Point(114, 305);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(95, 23);
            this.Remove.TabIndex = 14;
            this.Remove.Text = "REMOVE";
            this.Remove.UseVisualStyleBackColor = false;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // JoinServer
            // 
            this.JoinServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinServer.BackColor = System.Drawing.Color.Gray;
            this.JoinServer.FlatAppearance.BorderSize = 0;
            this.JoinServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinServer.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinServer.ForeColor = System.Drawing.Color.Black;
            this.JoinServer.Location = new System.Drawing.Point(503, 69);
            this.JoinServer.Name = "JoinServer";
            this.JoinServer.Size = new System.Drawing.Size(168, 23);
            this.JoinServer.TabIndex = 3;
            this.JoinServer.Text = "JOIN SERVER";
            this.JoinServer.UseVisualStyleBackColor = false;
            this.JoinServer.Click += new System.EventHandler(this.JoinServer_Click);
            // 
            // SetDescription
            // 
            this.SetDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SetDescription.BackColor = System.Drawing.Color.Gray;
            this.SetDescription.FlatAppearance.BorderSize = 0;
            this.SetDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetDescription.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetDescription.Location = new System.Drawing.Point(503, 266);
            this.SetDescription.Name = "SetDescription";
            this.SetDescription.Size = new System.Drawing.Size(133, 23);
            this.SetDescription.TabIndex = 11;
            this.SetDescription.Text = "SET DESCRIPTION";
            this.SetDescription.UseVisualStyleBackColor = false;
            this.SetDescription.Click += new System.EventHandler(this.SetDescription_Click);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBox.BackColor = System.Drawing.Color.Silver;
            this.DescriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionBox.Location = new System.Drawing.Point(503, 150);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(268, 109);
            this.DescriptionBox.TabIndex = 10;
            this.DescriptionBox.Text = "Description";
            // 
            // SetAlias
            // 
            this.SetAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SetAlias.BackColor = System.Drawing.Color.Gray;
            this.SetAlias.FlatAppearance.BorderSize = 0;
            this.SetAlias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetAlias.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetAlias.ForeColor = System.Drawing.Color.Black;
            this.SetAlias.Location = new System.Drawing.Point(715, 122);
            this.SetAlias.Name = "SetAlias";
            this.SetAlias.Size = new System.Drawing.Size(56, 23);
            this.SetAlias.TabIndex = 9;
            this.SetAlias.Text = "SET";
            this.SetAlias.UseVisualStyleBackColor = false;
            this.SetAlias.Click += new System.EventHandler(this.SetAlias_Click);
            // 
            // Alias
            // 
            this.Alias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Alias.BackColor = System.Drawing.Color.Silver;
            this.Alias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Alias.Location = new System.Drawing.Point(503, 124);
            this.Alias.MaxLength = 30;
            this.Alias.Name = "Alias";
            this.Alias.Size = new System.Drawing.Size(206, 20);
            this.Alias.TabIndex = 8;
            this.Alias.Text = "Alias";
            // 
            // Follow
            // 
            this.Follow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Follow.BackColor = System.Drawing.Color.Gray;
            this.Follow.FlatAppearance.BorderSize = 0;
            this.Follow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Follow.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Follow.ForeColor = System.Drawing.Color.Black;
            this.Follow.Location = new System.Drawing.Point(715, 96);
            this.Follow.Name = "Follow";
            this.Follow.Size = new System.Drawing.Size(56, 23);
            this.Follow.TabIndex = 7;
            this.Follow.Text = "JOIN";
            this.Follow.UseVisualStyleBackColor = false;
            this.Follow.Click += new System.EventHandler(this.Follow_Click);
            // 
            // UserID
            // 
            this.UserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserID.BackColor = System.Drawing.Color.Silver;
            this.UserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserID.Location = new System.Drawing.Point(565, 98);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(144, 20);
            this.UserID.TabIndex = 6;
            // 
            // LabelUserID
            // 
            this.LabelUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelUserID.AutoSize = true;
            this.LabelUserID.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUserID.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelUserID.Location = new System.Drawing.Point(500, 99);
            this.LabelUserID.Name = "LabelUserID";
            this.LabelUserID.Size = new System.Drawing.Size(64, 15);
            this.LabelUserID.TabIndex = 14;
            this.LabelUserID.Text = "Username";
            // 
            // ServerList
            // 
            this.ServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerList.BackColor = System.Drawing.Color.Gray;
            this.ServerList.FlatAppearance.BorderSize = 0;
            this.ServerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerList.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerList.ForeColor = System.Drawing.Color.Black;
            this.ServerList.Location = new System.Drawing.Point(706, 69);
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(65, 23);
            this.ServerList.TabIndex = 5;
            this.ServerList.Text = "SERVERS";
            this.ServerList.UseVisualStyleBackColor = false;
            this.ServerList.Click += new System.EventHandler(this.ServerList_Click);
            // 
            // AccountsView
            // 
            this.AccountsView.AllowColumnReorder = true;
            this.AccountsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountsView.BackColor = System.Drawing.Color.Gray;
            this.AccountsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AccountName,
            this.AliasColumn,
            this.Description});
            this.AccountsView.ContextMenuStrip = this.AccountsStrip;
            this.AccountsView.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountsView.ForeColor = System.Drawing.Color.Black;
            this.AccountsView.FullRowSelect = true;
            this.AccountsView.GridLines = true;
            this.AccountsView.HideSelection = false;
            this.AccountsView.Location = new System.Drawing.Point(13, 27);
            this.AccountsView.MultiSelect = false;
            this.AccountsView.Name = "AccountsView";
            this.AccountsView.Size = new System.Drawing.Size(484, 271);
            this.AccountsView.TabIndex = 17;
            this.AccountsView.UseCompatibleStateImageBehavior = false;
            this.AccountsView.View = System.Windows.Forms.View.Details;
            this.AccountsView.SelectedIndexChanged += new System.EventHandler(this.AccountsView_SelectedIndexChanged);
            this.AccountsView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AccountsView_MouseDown);
            this.AccountsView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AccountsView_MouseMove);
            this.AccountsView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AccountsView_MouseUp);
            // 
            // AccountName
            // 
            this.AccountName.Tag = "";
            this.AccountName.Text = "Name";
            this.AccountName.Width = 120;
            // 
            // AliasColumn
            // 
            this.AliasColumn.Text = "Alias";
            this.AliasColumn.Width = 112;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 251;
            // 
            // AccountsStrip
            // 
            this.AccountsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountsToolStripMenuItem,
            this.removeAccountToolStripMenuItem,
            this.copyUsernameToolStripMenuItem,
            this.moveGroupUpToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.getAuthenticationTicketToolStripMenuItem,
            this.copySecurityTokenToolStripMenuItem,
            this.copyRbxplayerLinkToolStripMenuItem,
            this.copyAppLinkToolStripMenuItem});
            this.AccountsStrip.Name = "contextMenuStrip1";
            this.AccountsStrip.Size = new System.Drawing.Size(209, 202);
            // 
            // addAccountsToolStripMenuItem
            // 
            this.addAccountsToolStripMenuItem.Name = "addAccountsToolStripMenuItem";
            this.addAccountsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.addAccountsToolStripMenuItem.Text = "Add Account";
            this.addAccountsToolStripMenuItem.Click += new System.EventHandler(this.addAccountsToolStripMenuItem_Click);
            // 
            // removeAccountToolStripMenuItem
            // 
            this.removeAccountToolStripMenuItem.Name = "removeAccountToolStripMenuItem";
            this.removeAccountToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.removeAccountToolStripMenuItem.Text = "Remove Account";
            this.removeAccountToolStripMenuItem.Click += new System.EventHandler(this.removeAccountToolStripMenuItem_Click);
            // 
            // copyUsernameToolStripMenuItem
            // 
            this.copyUsernameToolStripMenuItem.Name = "copyUsernameToolStripMenuItem";
            this.copyUsernameToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copyUsernameToolStripMenuItem.Text = "Copy Username";
            this.copyUsernameToolStripMenuItem.Click += new System.EventHandler(this.copyUsernameToolStripMenuItem_Click);
            // 
            // moveGroupUpToolStripMenuItem
            // 
            this.moveGroupUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.moveGroupUpToolStripMenuItem.Name = "moveGroupUpToolStripMenuItem";
            this.moveGroupUpToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.moveGroupUpToolStripMenuItem.Text = "Groups";
            // 
            // moveToToolStripMenuItem
            // 
            this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
            this.moveToToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.moveToToolStripMenuItem.Text = "Move Account To";
            this.moveToToolStripMenuItem.Click += new System.EventHandler(this.moveToToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.moveUpToolStripMenuItem.Text = "Move Group Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.moveDownToolStripMenuItem.Text = "Move Group Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // getAuthenticationTicketToolStripMenuItem
            // 
            this.getAuthenticationTicketToolStripMenuItem.Name = "getAuthenticationTicketToolStripMenuItem";
            this.getAuthenticationTicketToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.getAuthenticationTicketToolStripMenuItem.Text = "Get Authentication Ticket";
            this.getAuthenticationTicketToolStripMenuItem.Click += new System.EventHandler(this.getAuthenticationTicketToolStripMenuItem_Click);
            // 
            // copySecurityTokenToolStripMenuItem
            // 
            this.copySecurityTokenToolStripMenuItem.Name = "copySecurityTokenToolStripMenuItem";
            this.copySecurityTokenToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copySecurityTokenToolStripMenuItem.Text = "Copy Security Token";
            this.copySecurityTokenToolStripMenuItem.Click += new System.EventHandler(this.copySecurityTokenToolStripMenuItem_Click);
            // 
            // copyRbxplayerLinkToolStripMenuItem
            // 
            this.copyRbxplayerLinkToolStripMenuItem.Name = "copyRbxplayerLinkToolStripMenuItem";
            this.copyRbxplayerLinkToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copyRbxplayerLinkToolStripMenuItem.Text = "Copy rbx-player Link";
            this.copyRbxplayerLinkToolStripMenuItem.Click += new System.EventHandler(this.copyRbxplayerLinkToolStripMenuItem_Click);
            // 
            // copyAppLinkToolStripMenuItem
            // 
            this.copyAppLinkToolStripMenuItem.Name = "copyAppLinkToolStripMenuItem";
            this.copyAppLinkToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copyAppLinkToolStripMenuItem.Text = "Copy App Link";
            this.copyAppLinkToolStripMenuItem.Click += new System.EventHandler(this.copyAppLinkToolStripMenuItem_Click);
            // 
            // HideUsernamesCheckbox
            // 
            this.HideUsernamesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HideUsernamesCheckbox.AutoSize = true;
            this.HideUsernamesCheckbox.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideUsernamesCheckbox.ForeColor = System.Drawing.Color.White;
            this.HideUsernamesCheckbox.Location = new System.Drawing.Point(215, 310);
            this.HideUsernamesCheckbox.Name = "HideUsernamesCheckbox";
            this.HideUsernamesCheckbox.Size = new System.Drawing.Size(102, 19);
            this.HideUsernamesCheckbox.TabIndex = 15;
            this.HideUsernamesCheckbox.Text = "Hide Name(s)";
            this.HideUsernamesCheckbox.UseVisualStyleBackColor = true;
            this.HideUsernamesCheckbox.CheckedChanged += new System.EventHandler(this.HideUsernamesCheckbox_CheckedChanged);
            // 
            // InviteLinks
            // 
            this.InviteLinks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InviteLinks.BackColor = System.Drawing.Color.Gray;
            this.InviteLinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InviteLinks.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InviteLinks.ForeColor = System.Drawing.SystemColors.WindowText;
            this.InviteLinks.FormattingEnabled = true;
            this.InviteLinks.Location = new System.Drawing.Point(352, 306);
            this.InviteLinks.Name = "InviteLinks";
            this.InviteLinks.Size = new System.Drawing.Size(145, 23);
            this.InviteLinks.TabIndex = 16;
            this.InviteLinks.Text = "COPY INVITE LINK";
            this.InviteLinks.SelectedIndexChanged += new System.EventHandler(this.InviteLinks_SelectedIndexChanged);
            this.InviteLinks.TextUpdate += new System.EventHandler(this.InviteLinks_TextUpdate);
            // 
            // RobloxProcessTimer
            // 
            this.RobloxProcessTimer.Interval = 2500;
            this.RobloxProcessTimer.Tick += new System.EventHandler(this.RobloxProcessTimer_Tick);
            // 
            // RefreshTip
            // 
            this.RefreshTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.RefreshTip.ToolTipTitle = "Refresh";
            // 
            // RefreshLinks
            // 
            this.RefreshLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshLinks.BackColor = System.Drawing.Color.Gray;
            this.RefreshLinks.FlatAppearance.BorderSize = 0;
            this.RefreshLinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.RefreshLinks.ForeColor = System.Drawing.Color.Black;
            this.RefreshLinks.Location = new System.Drawing.Point(325, 305);
            this.RefreshLinks.Name = "RefreshLinks";
            this.RefreshLinks.Size = new System.Drawing.Size(21, 23);
            this.RefreshLinks.TabIndex = 18;
            this.RefreshLinks.Tag = "Refresh";
            this.RefreshLinks.Text = "R";
            this.RefreshTip.SetToolTip(this.RefreshLinks, "Refresh Account Links\r\nPress multiple times if you are running multiple accounts");
            this.RefreshLinks.UseVisualStyleBackColor = false;
            this.RefreshLinks.Click += new System.EventHandler(this.RefreshLinks_Click);
            // 
            // BrowserButton
            // 
            this.BrowserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowserButton.BackColor = System.Drawing.Color.Gray;
            this.BrowserButton.FlatAppearance.BorderSize = 0;
            this.BrowserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowserButton.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowserButton.ForeColor = System.Drawing.Color.Black;
            this.BrowserButton.Location = new System.Drawing.Point(638, 266);
            this.BrowserButton.Name = "BrowserButton";
            this.BrowserButton.Size = new System.Drawing.Size(133, 23);
            this.BrowserButton.TabIndex = 12;
            this.BrowserButton.Text = "ACCOUNT UTILITIES";
            this.BrowserButton.UseVisualStyleBackColor = false;
            this.BrowserButton.Click += new System.EventHandler(this.BrowserButton_Click);
            // 
            // ArgumentsB
            // 
            this.ArgumentsB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgumentsB.BackColor = System.Drawing.Color.Gray;
            this.ArgumentsB.FlatAppearance.BorderSize = 0;
            this.ArgumentsB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArgumentsB.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArgumentsB.ForeColor = System.Drawing.Color.Black;
            this.ArgumentsB.Location = new System.Drawing.Point(677, 69);
            this.ArgumentsB.Name = "ArgumentsB";
            this.ArgumentsB.Size = new System.Drawing.Size(23, 23);
            this.ArgumentsB.TabIndex = 4;
            this.ArgumentsB.Text = "A";
            this.ArgumentsB.UseVisualStyleBackColor = false;
            this.ArgumentsB.Click += new System.EventHandler(this.ArgumentsB_Click);
            // 
            // CurrentPlace
            // 
            this.CurrentPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentPlace.AutoSize = true;
            this.CurrentPlace.Font = new System.Drawing.Font("Montserrat SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPlace.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CurrentPlace.Location = new System.Drawing.Point(79, 7);
            this.CurrentPlace.Name = "CurrentPlace";
            this.CurrentPlace.Size = new System.Drawing.Size(91, 16);
            this.CurrentPlace.TabIndex = 21;
            this.CurrentPlace.Text = "Current Place";
            this.CurrentPlace.Click += new System.EventHandler(this.CurrentPlace_Click);
            // 
            // LabelPlaceID
            // 
            this.LabelPlaceID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPlaceID.AutoSize = true;
            this.LabelPlaceID.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlaceID.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelPlaceID.Location = new System.Drawing.Point(503, 27);
            this.LabelPlaceID.Name = "LabelPlaceID";
            this.LabelPlaceID.Size = new System.Drawing.Size(52, 15);
            this.LabelPlaceID.TabIndex = 3;
            this.LabelPlaceID.Text = "Place ID";
            // 
            // PlaceTimer
            // 
            this.PlaceTimer.Interval = 400;
            this.PlaceTimer.Tick += new System.EventHandler(this.PlaceTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Montserrat SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(503, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 34);
            this.button1.TabIndex = 22;
            this.button1.Text = "MINIMIZE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "GAME:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.IndianRed;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Montserrat SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(696, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 24;
            this.button2.Text = "EXIT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 7.749999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(601, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "ROBLOX ACCOUNT MANAGER";
            // 
            // AccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(783, 340);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CurrentPlace);
            this.Controls.Add(this.RefreshLinks);
            this.Controls.Add(this.ArgumentsB);
            this.Controls.Add(this.BrowserButton);
            this.Controls.Add(this.InviteLinks);
            this.Controls.Add(this.HideUsernamesCheckbox);
            this.Controls.Add(this.AccountsView);
            this.Controls.Add(this.ServerList);
            this.Controls.Add(this.LabelUserID);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.Follow);
            this.Controls.Add(this.Alias);
            this.Controls.Add(this.SetAlias);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.SetDescription);
            this.Controls.Add(this.JoinServer);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.LabelJobID);
            this.Controls.Add(this.LabelPlaceID);
            this.Controls.Add(this.JobID);
            this.Controls.Add(this.PlaceID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(649, 340);
            this.Name = "AccountManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roblox Account Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountManager_FormClosed);
            this.Load += new System.EventHandler(this.AccountManager_Load);
            this.Shown += new System.EventHandler(this.AccountManager_Shown);
            this.AccountsStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox PlaceID;
        public System.Windows.Forms.TextBox JobID;
        private System.Windows.Forms.Label LabelJobID;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button JoinServer;
        private System.Windows.Forms.Button SetDescription;
        private System.Windows.Forms.RichTextBox DescriptionBox;
        private System.Windows.Forms.Button SetAlias;
        private System.Windows.Forms.TextBox Alias;
        private System.Windows.Forms.Button Follow;
        private System.Windows.Forms.TextBox UserID;
        private System.Windows.Forms.Label LabelUserID;
        private System.Windows.Forms.Button ServerList;
        public System.Windows.Forms.ListView AccountsView;
        private System.Windows.Forms.ColumnHeader AccountName;
        private System.Windows.Forms.ColumnHeader AliasColumn;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ContextMenuStrip AccountsStrip;
        private System.Windows.Forms.ToolStripMenuItem addAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.CheckBox HideUsernamesCheckbox;
        private System.Windows.Forms.ComboBox InviteLinks;
        private System.Windows.Forms.Timer RobloxProcessTimer;
        private System.Windows.Forms.ToolStripMenuItem getAuthenticationTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRbxplayerLinkToolStripMenuItem;
        private System.Windows.Forms.ToolTip RefreshTip;
        private System.Windows.Forms.ToolStripMenuItem copyUsernameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySecurityTokenToolStripMenuItem;
        private System.Windows.Forms.Button BrowserButton;
        private System.Windows.Forms.Button ArgumentsB;
        private System.Windows.Forms.Button RefreshLinks;
        private System.Windows.Forms.Label CurrentPlace;
        private System.Windows.Forms.Label LabelPlaceID;
        private System.Windows.Forms.Timer PlaceTimer;
        private System.Windows.Forms.ToolStripMenuItem moveGroupUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAppLinkToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label2;
    }
}