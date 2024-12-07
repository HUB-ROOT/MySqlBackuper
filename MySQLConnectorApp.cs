using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SqlBackuper
{
    public partial class MySQLConnectorApp : Form
    {
        private string connectionString = @"Data Source=database.db;Version=3;";

        public MySQLConnectorApp()
        {
            InitializeComponent();
            CreateDatabase();

        }
        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Connections (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Server TEXT NOT NULL,
                        Port INTEGER NOT NULL,
                        User TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Database TEXT NOT NULL
                    );
                ";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // CREATE operation (Insert)
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            // Check if a record already exists
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Connections";
                using (var command = new SQLiteCommand(checkQuery, connection))
                {
                    long count = (long)command.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Only one connection record can exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Do not insert if a record already exists
                    }
                }
                connection.Close();
            }

            // Proceed with the insertion if no records exist
            string server = txtServer.Text;
            int port = Convert.ToInt32(txtPort.Text);
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string database = txtDatabase.Text;

            string insertQuery = "INSERT INTO Connections (Server, Port, User, Password, Database) VALUES (@Server, @Port, @User, @Password, @Database)";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Server", server);
                    command.Parameters.AddWithValue("@Port", port);
                    command.Parameters.AddWithValue("@User", user);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Database", database);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            LoadData();
        }

        // READ operation (Select)
        private void btnRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Connections";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvConnections.DataSource = dt;
                }
                connection.Close();
            }
        }

        // UPDATE operation
        
        // DELETE operation
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvConnections.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvConnections.SelectedRows[0].Cells["Id"].Value);

                string deleteQuery = "DELETE FROM Connections WHERE Id = @Id";

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                LoadData();
            }
        }

        // Double-click to load selected row data into textboxes
        private void dgvConnections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Ensure a row is selected
            {
                // Get the selected row
                DataGridViewRow row = dgvConnections.Rows[e.RowIndex];

                // Populate the textboxes with the values from the selected row
                txtid.Text = row.Cells["id"].Value.ToString();
                txtServer.Text = row.Cells["Server"].Value.ToString();
                txtPort.Text = row.Cells["Port"].Value.ToString();
                txtUser.Text = row.Cells["User"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtDatabase.Text = row.Cells["Database"].Value.ToString();
            }
        }

        private void MySQLConnectorApp_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {
                int id = Convert.ToInt32(txtid.Text);  // Get the ID from txtId

                string deleteQuery = "DELETE FROM Connections WHERE Id = @Id";

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);  // Pass the ID to the query
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                // Reload the data after deletion
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a connection to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Ensure that there is exactly one row selected in the DataGridView
            if (dgvConnections.SelectedRows.Count == 1)
            {
                // Get the ID from the textbox (assuming txtid.Text contains the ID of the record to update)
                int id = Convert.ToInt32(txtid.Text);

                // Get the updated values from the textboxes
                string server = txtServer.Text;
                int port = Convert.ToInt32(txtPort.Text);
                string user = txtUser.Text;
                string password = txtPassword.Text;
                string database = txtDatabase.Text;

                // Prepare the UPDATE query with placeholders for parameters
                string updateQuery = "UPDATE Connections SET Server = @Server, Port = @Port, User = @User, Password = @Password, Database = @Database WHERE Id = @Id";

                // Execute the update command using SQLite
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(updateQuery, connection))
                    {
                        // Add parameters to the query to prevent SQL injection
                        command.Parameters.AddWithValue("@Server", server);
                        command.Parameters.AddWithValue("@Port", port);
                        command.Parameters.AddWithValue("@User", user);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Database", database);
                        command.Parameters.AddWithValue("@Id", id);  // Use the ID from txtid.Text for WHERE clause

                        // Execute the update command
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                // Reload the data in the DataGridView after the update
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

    }
}
