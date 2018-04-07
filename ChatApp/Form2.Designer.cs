namespace ChatApp
{
    partial class FrmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChat));
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.online = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChat = new System.Windows.Forms.Button();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.tmrGetMessages = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.userRegDataSet = new ChatApp.UserRegDataSet();
            this.tblOnlineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblOnlineTableAdapter = new ChatApp.UserRegDataSetTableAdapters.tblOnlineTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.userRegDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOnlineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.Color.LightGray;
            this.lstUsers.Enabled = false;
            this.lstUsers.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 23;
            this.lstUsers.Location = new System.Drawing.Point(737, 42);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(232, 533);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.TabStop = false;
            // 
            // online
            // 
            this.online.AutoSize = true;
            this.online.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.online.Location = new System.Drawing.Point(733, 16);
            this.online.Name = "online";
            this.online.Size = new System.Drawing.Size(88, 23);
            this.online.TabIndex = 2;
            this.online.Text = "online";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(17, 16);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(114, 23);
            this.message.TabIndex = 3;
            this.message.Text = "messages";
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtChat.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(21, 542);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(595, 31);
            this.txtChat.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "say something";
            // 
            // btnChat
            // 
            this.btnChat.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.Location = new System.Drawing.Point(622, 520);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(100, 55);
            this.btnChat.TabIndex = 6;
            this.btnChat.TabStop = false;
            this.btnChat.Text = "chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // lstChat
            // 
            this.lstChat.BackColor = System.Drawing.Color.LightGray;
            this.lstChat.Font = new System.Drawing.Font("Courier New", 10F);
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lstChat.ItemHeight = 16;
            this.lstChat.Location = new System.Drawing.Point(21, 42);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(701, 468);
            this.lstChat.TabIndex = 7;
            this.lstChat.TabStop = false;
            this.lstChat.UseTabStops = false;
            // 
            // tmrGetMessages
            // 
            this.tmrGetMessages.Enabled = true;
            this.tmrGetMessages.Interval = 1000;
            this.tmrGetMessages.Tick += new System.EventHandler(this.tmrGetMessages_Tick);
            // 
            // userRegDataSet
            // 
            this.userRegDataSet.DataSetName = "UserRegDataSet";
            this.userRegDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblOnlineBindingSource
            // 
            this.tblOnlineBindingSource.DataMember = "tblOnline";
            this.tblOnlineBindingSource.DataSource = this.userRegDataSet;
            // 
            // tblOnlineTableAdapter
            // 
            this.tblOnlineTableAdapter.ClearBeforeFill = true;
            // 
            // FrmChat
            // 
            this.AcceptButton = this.btnChat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(989, 596);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.message);
            this.Controls.Add(this.online);
            this.Controls.Add(this.lstUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DaleChat™ ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChat_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userRegDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOnlineBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label online;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.Timer tmrGetMessages;
        private System.Windows.Forms.Timer timer1;
        private UserRegDataSet userRegDataSet;
        private System.Windows.Forms.BindingSource tblOnlineBindingSource;
        private UserRegDataSetTableAdapters.tblOnlineTableAdapter tblOnlineTableAdapter;
    }
}