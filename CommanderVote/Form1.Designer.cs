namespace CommanderVote
{
    partial class Form1
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
            this.lstBoxGroups = new System.Windows.Forms.ListBox();
            this.lstBoxUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerCommanderVotePause = new System.Windows.Forms.Timer(this.components);
            this.timerNewGroupPause = new System.Windows.Forms.Timer(this.components);
            this.timerCheckVoteStatus = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lstBoxGroups
            // 
            this.lstBoxGroups.FormattingEnabled = true;
            this.lstBoxGroups.Location = new System.Drawing.Point(39, 50);
            this.lstBoxGroups.Name = "lstBoxGroups";
            this.lstBoxGroups.Size = new System.Drawing.Size(214, 394);
            this.lstBoxGroups.TabIndex = 0;
            // 
            // lstBoxUsers
            // 
            this.lstBoxUsers.FormattingEnabled = true;
            this.lstBoxUsers.Location = new System.Drawing.Point(333, 50);
            this.lstBoxUsers.Name = "lstBoxUsers";
            this.lstBoxUsers.Size = new System.Drawing.Size(292, 394);
            this.lstBoxUsers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // timerCommanderVotePause
            // 
            this.timerCommanderVotePause.Interval = 30000;
            this.timerCommanderVotePause.Tick += new System.EventHandler(this.timerCommanderVotePause_Tick);
            // 
            // timerNewGroupPause
            // 
            this.timerNewGroupPause.Enabled = true;
            this.timerNewGroupPause.Interval = 15000;
            this.timerNewGroupPause.Tick += new System.EventHandler(this.timerNewGroupPause_Tick);
            // 
            // timerCheckVoteStatus
            // 
            this.timerCheckVoteStatus.Interval = 1500;
            this.timerCheckVoteStatus.Tick += new System.EventHandler(this.timerCheckVoteStatus_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 555);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBoxUsers);
            this.Controls.Add(this.lstBoxGroups);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxGroups;
        private System.Windows.Forms.ListBox lstBoxUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerCommanderVotePause;
        private System.Windows.Forms.Timer timerNewGroupPause;
        private System.Windows.Forms.Timer timerCheckVoteStatus;
    }
}

