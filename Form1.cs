using MySql.Data.MySqlClient;
using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SqlBackuper
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=database.db;Version=3;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string database = txtDatabase.Text;
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string port = txtPort.Text;

            // Open FolderBrowserDialog to select the backup destination
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupDirectory = folderDialog.SelectedPath;
                    string backupFile = Path.Combine(backupDirectory, $"{database}_{DateTime.Now:yyyyMMdd_HHmmss}.sql");

                    try
                    {
                        // Path to mysqldump utility (adjust to your MySQL installation path)
                        string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe";

                        // Modify the command to correctly handle host and port
                        string arguments = $"-h {server} -P {port} -u {user} -p{password} {database}";

                        // Start the mysqldump process
                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            FileName = mysqldumpPath,
                            Arguments = arguments,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,  // Capture error output
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (Process process = Process.Start(processStartInfo))
                        {
                            // Show the progress bar and initialize the backup progress
                            progressBar.Visible = true;
                            progressBar.Value = 0;

                            // Read the SQL dump (to simulate progress)
                            using (StreamReader reader = new StreamReader(process.StandardOutput.BaseStream))
                            {
                                string sqlContent = reader.ReadToEnd();

                                // Encrypt the SQL content
                                string encryptionKey = "SabirRahmati@encryptionSaltKey"; // Replace with a more secure method
                                string encryptedContent = Encrypt(sqlContent, encryptionKey);

                                // Save the encrypted content to the backup file
                                string encryptedBackupFile = Path.Combine(backupDirectory, $"{database}_{DateTime.Now:yyyyMMdd_HHmmss}.sql.enc");
                                File.WriteAllText(encryptedBackupFile, encryptedContent);
                            }

                            // Capture any error output
                            string errorOutput = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            if (!string.IsNullOrEmpty(errorOutput))
                            {
                                MessageBox.Show($"Error during backup: {errorOutput}");
                            }
                            else
                            {
                                MessageBox.Show($"Backup completed successfully. Encrypted file saved to: {backupDirectory}");
                            }

                            // Hide the progress bar after the backup is complete
                            progressBar.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during backup: {ex.Message}");
                        progressBar.Visible = false;  // Hide progress bar if there is an error
                    }
                }
            }
        }


        private void sqlite_Click(object sender, EventArgs e)
        {
            Authenticator ma = new Authenticator();
            ma.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConnectionDetails();
        }
        private void LoadConnectionDetails()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Check if the Connections table has any records
                    string checkQuery = "SELECT COUNT(*) FROM Connections";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, connection))
                    {
                        int recordCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (recordCount == 0) // If no records exist in the Connections table
                        {
                            // Open MySQLConnectorApp form
                            MySQLConnectorApp mysqlForm = new MySQLConnectorApp();
                            mysqlForm.Show();
                            this.Hide(); // Optionally hide the current form
                            return; // Exit the method early, as we don't want to load connection details
                        }
                    }

                    // If there are records, load the connection details
                    string query = "SELECT Server, Port, User, Password, Database FROM Connections LIMIT 1";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtServer.Text = reader["Server"].ToString();
                                txtPort.Text = reader["Port"].ToString();
                                txtUser.Text = reader["User"].ToString();
                                txtPassword.Text = reader["Password"].ToString();
                                txtDatabase.Text = reader["Database"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading connection details: {ex.Message}");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string database = txtDatabase.Text;
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string port = txtPort.Text;

            // Open OpenFileDialog to select the backup SQL file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Encrypted SQL Files (*.sql.enc)|*.sql.enc|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string encryptedBackupFile = openFileDialog.FileName;

                    try
                    {
                        // Read the encrypted content from the file
                        string encryptedContent = File.ReadAllText(encryptedBackupFile);

                        // Decrypt the content
                        string encryptionKey = "SabirRahmati@encryptionSaltKey"; // Replace with a more secure method
                        string sqlContent = Decrypt(encryptedContent, encryptionKey);

                        // Path to mysql utility (adjust to your MySQL installation path)
                        string mysqlPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe";

                        // Create the restore command
                        string arguments = $"-h {server} -P {port} -u {user} -p{password} {database}";

                        // Start the mysql process to restore the database from the decrypted SQL content
                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            FileName = mysqlPath,
                            Arguments = arguments,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,  // Capture error output
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (Process process = Process.Start(processStartInfo))
                        {
                            // Show the progress bar and initialize the restore progress
                            progressBar.Visible = true;
                            progressBar.Value = 0;

                            // Write the decrypted SQL content to the mysql process input stream
                            using (StreamWriter writer = new StreamWriter(process.StandardInput.BaseStream))
                            {
                                writer.Write(sqlContent);
                            }

                            // Capture any error output
                            string errorOutput = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            if (!string.IsNullOrEmpty(errorOutput))
                            {
                                MessageBox.Show($"Error during restore: {errorOutput}");
                            }
                            else
                            {
                                MessageBox.Show("Restore completed successfully.");
                            }

                            // Hide the progress bar after the restore is complete
                            progressBar.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during restore: {ex.Message}");
                        progressBar.Visible = false;  // Hide progress bar if there is an error
                    }
                }
            }
        }


        private static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16]; // 16 bytes salt for AES
                rng.GetBytes(salt);
                return salt;
            }
        }

        // Encrypts the plain text with a salted key
        public string Encrypt(string plainText, string key)
        {
            // Generate a random salt
            byte[] salt = GenerateSalt();

            // Combine the key and the salt to derive the final encryption key
            using (Aes aesAlg = Aes.Create())
            {
                // Concatenate the key with the salt (pad key to 32 bytes if necessary)
                aesAlg.Key = GenerateKeyFromPassword(key, salt);

                // Use zero IV for simplicity (can be randomized for additional security)
                aesAlg.IV = new byte[16];

                // Create the encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Write the salt at the beginning of the encrypted file
                    msEncrypt.Write(salt, 0, salt.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    // Return the encrypted content (salt + encrypted data)
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        // Decrypts the cipher text with the salted key
        public string Decrypt(string cipherText, string key)
        {
            // Decode the base64 encrypted content
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Extract the salt (first 16 bytes) from the cipher text
            byte[] salt = new byte[16];
            Array.Copy(cipherBytes, 0, salt, 0, salt.Length);

            // Combine the key and the salt to derive the final decryption key
            using (Aes aesAlg = Aes.Create())
            {
                // Concatenate the key with the salt (pad key to 32 bytes if necessary)
                aesAlg.Key = GenerateKeyFromPassword(key, salt);

                // Use zero IV for simplicity
                aesAlg.IV = new byte[16];

                // Create the decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes, salt.Length, cipherBytes.Length - salt.Length))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Return the decrypted text
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        // Derives a key from the password and salt using PBKDF2 (Password-Based Key Derivation Function 2)
        private byte[] GenerateKeyFromPassword(string password, byte[] salt)
        {
            using (var keyDerivation = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                // Return a 256-bit key (32 bytes) for AES-256
                return keyDerivation.GetBytes(32);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string port = txtPort.Text;
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string database = txtDatabase.Text;

            try
            {
                // Build the MySQL connection string
                string connectionString = $"Server={server};Port={port};Database={database};User ID={user};Password={password};";

                // Create the MySQL connection object
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Try opening the connection
                    lbltestcon.Text = $"Connection successful! {MessageBoxButtons.OK}";
                    lbltestcon.ForeColor=Color.Green;
                }
            }
            catch (Exception ex)
            {
                // If there is an error, show the error message
                lbltestcon.Text = $"Connection failed!";
                lbltestcon.ForeColor = Color.Red;
            }
        }
    }
}
       