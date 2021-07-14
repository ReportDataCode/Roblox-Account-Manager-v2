namespace RBX_Alt_Manager
{
    partial class ArgumentsForm
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
            this.TeleportCB = new System.Windows.Forms.CheckBox();
            this.OldJoin = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TeleportCB
            // 
            this.TeleportCB.AutoSize = true;
            this.TeleportCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeleportCB.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeleportCB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TeleportCB.Location = new System.Drawing.Point(12, 12);
            this.TeleportCB.Name = "TeleportCB";
            this.TeleportCB.Size = new System.Drawing.Size(80, 19);
            this.TeleportCB.TabIndex = 0;
            this.TeleportCB.Text = "isTeleport";
            this.TeleportCB.UseVisualStyleBackColor = true;
            this.TeleportCB.CheckedChanged += new System.EventHandler(this.TeleportCB_CheckedChanged);
            // 
            // OldJoin
            // 
            this.OldJoin.AutoSize = true;
            this.OldJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OldJoin.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OldJoin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OldJoin.Location = new System.Drawing.Point(12, 46);
            this.OldJoin.Name = "OldJoin";
            this.OldJoin.Size = new System.Drawing.Size(144, 19);
            this.OldJoin.TabIndex = 1;
            this.OldJoin.Text = "Use Old Join Method";
            this.OldJoin.UseVisualStyleBackColor = true;
            this.OldJoin.CheckedChanged += new System.EventHandler(this.OldJoin_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(91, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "CLOSE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ArgumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(168, 75);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OldJoin);
            this.Controls.Add(this.TeleportCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(168, 75);
            this.MinimumSize = new System.Drawing.Size(168, 75);
            this.Name = "ArgumentsForm";
            this.Text = "ArgumentsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArgumentsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox TeleportCB;
        private System.Windows.Forms.CheckBox OldJoin;
        private System.Windows.Forms.Button button1;
    }
}