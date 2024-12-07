namespace SqlBackuper
{
    partial class Authenticator
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
            txtpasskey = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtpasskey
            // 
            txtpasskey.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            txtpasskey.Location = new Point(12, 12);
            txtpasskey.Name = "txtpasskey";
            txtpasskey.PasswordChar = '*';
            txtpasskey.Size = new Size(1039, 149);
            txtpasskey.TabIndex = 0;
            txtpasskey.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(1057, 12);
            button1.Name = "button1";
            button1.Size = new Size(170, 149);
            button1.TabIndex = 1;
            button1.Text = "Auth";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Authenticator
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 169);
            Controls.Add(button1);
            Controls.Add(txtpasskey);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Authenticator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Authenticator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtpasskey;
        private Button button1;
    }
}