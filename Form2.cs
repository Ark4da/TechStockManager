using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace TechStockManager
{
    public partial class LoginForm : Form
    {
        private DB db = new DB(); // Object for working with the database
        public string UserDepartment { get; private set; } // User department that will be available after authorization

        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private bool AuthenticateUser(string username, string password, out string department)
        {
            department = string.Empty; // Initializing department

            try
            {
                db.OpenConnection();

                string query = "SELECT PasswordHash, Department FROM users WHERE Username = @Username";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@Username", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // If user is found
                {
                    string storedHash = reader["PasswordHash"].ToString();
                    department = reader["Department"].ToString(); // Getting user department

                    // Verifying password
                    if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                    {
                        return true; // Password is correct
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return false; // If something went wrong
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                if (AuthenticateUser(username, password, out string department))
                {
                    // Saving user department
                    UserDepartment = department;

                    Form1 form1 = new Form1(department);
                    this.Hide();
                    form1.ShowDialog(); // Blocks the current window until Form1 is closed
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handling the "Show Password" checkbox state change event
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If the "Show Password" checkbox is checked, display the password text, otherwise hide it
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }
    }
}