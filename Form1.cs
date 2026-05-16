using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TechStockManager
{
    public partial class Form1 : Form // Main menu
    {
        private DB db = new DB(); // Initializing database connection
        public string UserDepartment { get; private set; } // User department

        public Form1(string department)
        {
            try
            {
                InitializeComponent(); // Initializing form components

                // Binding buttons and menu items to methods for opening forms
                btnOpenForm3.Click += (sender, e) => OpenForm3();
                btnOpenForm4.Click += (sender, e) => OpenForm4();
                btnOpenForm5.Click += (sender, e) => OpenForm5();
                btnOpenForm6.Click += (sender, e) => OpenForm6();
                btnOpenForm7.Click += (sender, e) => OpenForm7();
                btnOpenForm8.Click += (sender, e) => OpenForm8();
                ManufacturerToolStripMenuItem.Click += (sender, e) => OpenForm9();
                âèõ³äToolStripMenuItem.Click += (sender, e) => Application.Exit(); // Closing the application
                this.lightThemeMenuItem.Click += new System.EventHandler(this.lightThemeMenuItem_Click);
                this.darkThemeMenuItem.Click += new System.EventHandler(this.darkThemeMenuItem_Click);

                UserDepartment = department; // Saving the passed department
                ConfigureMainPage(department); // Configuring interface depending on department
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Form1: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Methods for opening other forms with department transfer
        private void OpenForm3() => new Form3(UserDepartment).Show();
        private void OpenForm4() => new Form4(UserDepartment).Show();
        private void OpenForm5() => new Form5(UserDepartment).Show();
        private void OpenForm6() => new Form6(UserDepartment).Show();
        private void OpenForm7() => new Form7(UserDepartment).Show();
        private void OpenForm8() => new Form8(UserDepartment).Show();
        private void OpenForm9() => new Form9(UserDepartment).Show();
        private void OpenForm10() => new Form10().Show(); // Without department transfer

        // Applying light theme
        private void lightThemeMenuItem_Click(object sender, EventArgs e)
        {
            ThemeManager.ApplyLightTheme(this);
            ThemeManager.ApplyThemeToAllForms();
        }

        // Applying dark theme
        private void darkThemeMenuItem_Click(object sender, EventArgs e)
        {
            ThemeManager.ApplyDarkTheme(this);
            ThemeManager.ApplyThemeToAllForms();
        }

        // Configuring the main page depending on the user's department
        private void ConfigureMainPage(string department)
        {
            if (department == "computer")
            {
                lblTitle.Text = "Computer\nEquipment\nDepartment";
                this.Text = "Main Form (Computer Equipment Department)";
                btnOpenForm7.Visible = false;
            }
            else if (department == "mobile")
            {
                lblTitle.Text = "Mobile\nDevices\nDepartment";
                this.Text = "Main Form (Mobile Devices Department)";
                btnOpenForm7.Visible = false;
            }
            else if (department == "admin")
            {
                lblTitle.Text = "Admin";
                this.Text = "Main Form (Administrator)";
                btnOpenForm4.Visible = false;
            }
            else if (department == "television")
            {
                lblTitle.Text = "Television\nDepartment";
                this.Text = "Main Form (Television Department)";
                btnOpenForm7.Visible = false;
            }
            else if (department == "audio")
            {
                lblTitle.Text = "Audio\nDevices\nDepartment";
                this.Text = "Main Form (Audio Devices Department)";
                btnOpenForm7.Visible = false;
            }
            else
            {
                lblTitle.Text = "Warehouse Main Page";
                this.Text = "Main Form (Warehouse Main Page)";
                btnOpenForm7.Visible = false;
            }
        }

        // Exiting the application through the menu
        private void âèõ³äToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Changing user — returning to login form
        private void çì³íèòèÊîðèñòóâà÷àToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                string newDepartment = loginForm.UserDepartment;
                Form1 newForm = new Form1(newDepartment);
                newForm.Show();
            }

            this.Close(); // Closing the old form after user change
        }
    }
}