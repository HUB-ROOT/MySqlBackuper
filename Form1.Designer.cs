namespace SqlBackuper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBackup = new Button();
            txtServer = new TextBox();
            txtDatabase = new TextBox();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            txtPort = new TextBox();
            sqlite = new Button();
            btnRestore = new Button();
            btnTestConnection = new Button();
            lbltestcon = new Label();
            pictureBox1 = new PictureBox();
            progressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnBackup
            // 
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackup.Location = new Point(111, 347);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(922, 109);
            btnBackup.TabIndex = 0;
            btnBackup.Text = "Backup";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // txtServer
            // 
            txtServer.Location = new Point(111, 592);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(133, 39);
            txtServer.TabIndex = 1;
            txtServer.Text = " ";
            txtServer.Visible = false;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(308, 592);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(133, 39);
            txtDatabase.TabIndex = 2;
            txtDatabase.Text = "  ";
            txtDatabase.Visible = false;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(505, 592);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(133, 39);
            txtUser.TabIndex = 3;
            txtUser.Text = " ";
            txtUser.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(702, 592);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(133, 39);
            txtPassword.TabIndex = 4;
            txtPassword.Text = " ";
            txtPassword.Visible = false;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(899, 592);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(133, 39);
            txtPort.TabIndex = 5;
            txtPort.Visible = false;
            // 
            // sqlite
            // 
            sqlite.FlatStyle = FlatStyle.Flat;
            sqlite.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            sqlite.ForeColor = Color.CornflowerBlue;
            sqlite.Location = new Point(111, 83);
            sqlite.Name = "sqlite";
            sqlite.Size = new Size(411, 46);
            sqlite.TabIndex = 6;
            sqlite.Text = "SET DB CREDENTIALS";
            sqlite.UseVisualStyleBackColor = true;
            sqlite.Click += sqlite_Click;
            // 
            // btnRestore
            // 
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnRestore.Location = new Point(111, 462);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(922, 109);
            btnRestore.TabIndex = 7;
            btnRestore.Text = "RESTORE DATABASE";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.FlatStyle = FlatStyle.Flat;
            btnTestConnection.ForeColor = Color.CornflowerBlue;
            btnTestConnection.Location = new Point(111, 135);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(249, 81);
            btnTestConnection.TabIndex = 8;
            btnTestConnection.Text = "Test Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // lbltestcon
            // 
            lbltestcon.AutoSize = true;
            lbltestcon.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbltestcon.Location = new Point(111, 229);
            lbltestcon.Name = "lbltestcon";
            lbltestcon.Size = new Size(66, 41);
            lbltestcon.TabIndex = 9;
            lbltestcon.Text = "----";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._9850774;
            pictureBox1.Location = new Point(850, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 191);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(111, 669);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(921, 46);
            progressBar.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 789);
            Controls.Add(progressBar);
            Controls.Add(pictureBox1);
            Controls.Add(lbltestcon);
            Controls.Add(btnTestConnection);
            Controls.Add(btnRestore);
            Controls.Add(sqlite);
            Controls.Add(btnBackup);
            Controls.Add(txtPort);
            Controls.Add(txtPassword);
            Controls.Add(txtUser);
            Controls.Add(txtDatabase);
            Controls.Add(txtServer);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.Coral;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MYSQL BACKUPER";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBackup;
        private TextBox txtServer;
        private TextBox txtDatabase;
        private TextBox txtUser;
        private TextBox txtPassword;
        private TextBox txtPort;
        private Button sqlite;
        private Button btnRestore;
        private Button btnTestConnection;
        private Label lbltestcon;
        private PictureBox pictureBox1;
        private ProgressBar progressBar;
    }
}
