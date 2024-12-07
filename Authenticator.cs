using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlBackuper
{
    public partial class Authenticator : Form
    {
        public Authenticator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var passKey = "YourSecretPassKey";
            if(txtpasskey.Text == passKey)
            {
                MySQLConnectorApp ma = new MySQLConnectorApp();
                ma.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid PassKey");
            }
        }
    }
}
