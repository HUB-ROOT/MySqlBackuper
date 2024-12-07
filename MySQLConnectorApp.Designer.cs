namespace SqlBackuper
{
    partial class MySQLConnectorApp
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
            txtPort = new TextBox();
            txtPassword = new TextBox();
            txtUser = new TextBox();
            txtDatabase = new TextBox();
            txtServer = new TextBox();
            btnCreate = new Button();
            dgvConnections = new DataGridView();
            txtid = new TextBox();
            btndelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConnections).BeginInit();
            SuspendLayout();
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPort.Location = new Point(625, 137);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(200, 50);
            txtPort.TabIndex = 10;
            txtPort.Text = "3307";
            txtPort.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(831, 137);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(267, 50);
            txtPassword.TabIndex = 9;
            txtPassword.Text = "sabir@123";
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUser.Location = new Point(457, 137);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(162, 50);
            txtUser.TabIndex = 8;
            txtUser.Text = "sa";
            txtUser.UseSystemPasswordChar = true;
            txtUser.UseWaitCursor = true;
            // 
            // txtDatabase
            // 
            txtDatabase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDatabase.Location = new Point(308, 137);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(143, 50);
            txtDatabase.TabIndex = 7;
            txtDatabase.Text = "hotelms";
            txtDatabase.UseSystemPasswordChar = true;
            // 
            // txtServer
            // 
            txtServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtServer.Location = new Point(12, 137);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(290, 50);
            txtServer.TabIndex = 6;
            txtServer.Text = "127.0.0.1";
            txtServer.UseSystemPasswordChar = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(1104, 137);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(164, 50);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "save";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click_1;
            // 
            // dgvConnections
            // 
            dgvConnections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConnections.Location = new Point(12, 205);
            dgvConnections.Name = "dgvConnections";
            dgvConnections.RowHeadersWidth = 82;
            dgvConnections.RowTemplate.Height = 41;
            dgvConnections.Size = new Size(1256, 100);
            dgvConnections.TabIndex = 12;
            dgvConnections.CellDoubleClick += dgvConnections_CellDoubleClick;
            // 
            // txtid
            // 
            txtid.Location = new Point(17, 47);
            txtid.Name = "txtid";
            txtid.Size = new Size(200, 39);
            txtid.TabIndex = 14;
            // 
            // btndelete
            // 
            btndelete.Location = new Point(223, 47);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(150, 39);
            btndelete.TabIndex = 15;
            btndelete.Text = "Delete";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 12);
            label1.Name = "label1";
            label1.Size = new Size(37, 32);
            label1.TabIndex = 16;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 102);
            label2.Name = "label2";
            label2.Size = new Size(112, 32);
            label2.TabIndex = 17;
            label2.Text = "Database";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(63, 32);
            label3.TabIndex = 18;
            label3.Text = "Host";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(457, 102);
            label4.Name = "label4";
            label4.Size = new Size(61, 32);
            label4.TabIndex = 19;
            label4.Text = "User";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(625, 102);
            label5.Name = "label5";
            label5.Size = new Size(56, 32);
            label5.TabIndex = 20;
            label5.Text = "Port";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(831, 102);
            label6.Name = "label6";
            label6.Size = new Size(97, 32);
            label6.TabIndex = 21;
            label6.Text = "PassKey";
            // 
            // MySQLConnectorApp
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 317);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btndelete);
            Controls.Add(txtid);
            Controls.Add(dgvConnections);
            Controls.Add(btnCreate);
            Controls.Add(txtPort);
            Controls.Add(txtPassword);
            Controls.Add(txtUser);
            Controls.Add(txtDatabase);
            Controls.Add(txtServer);
            Name = "MySQLConnectorApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MySQLConnectorApp";
            Load += MySQLConnectorApp_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConnections).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPort;
        private TextBox txtPassword;
        private TextBox txtUser;
        private TextBox txtDatabase;
        private TextBox txtServer;
        private Button btnCreate;
        private DataGridView dgvConnections;
        private TextBox txtid;
        private Button btndelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}