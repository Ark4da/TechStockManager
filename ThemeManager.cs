using System.Drawing;
using System.Windows.Forms;

namespace TechStockManager
{
    public static class ThemeManager
    {
        public static bool IsDarkTheme { get; private set; } = false; // Отслеживает текущую тему

        // Метод для переключения на светлую тему
        public static void ApplyLightTheme(Form form)
        {
            form.BackColor = Color.White;
            form.ForeColor = Color.Black;

            foreach (Control control in form.Controls)
            {
                if (control is MenuStrip menuStrip)
                {
                    menuStrip.BackColor = Color.White;
                    menuStrip.ForeColor = Color.Black;
                }
                else if (control is Button button)
                {
                    button.BackColor = Color.LightGray;
                    button.ForeColor = Color.Black;
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.BackgroundColor = Color.White;
                    dataGridView.DefaultCellStyle.BackColor = Color.White;
                    dataGridView.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            IsDarkTheme = false;
        }

        // Метод для переключения на темную тему
        public static void ApplyDarkTheme(Form form)
        {
            form.BackColor = Color.FromArgb(30, 30, 30);
            form.ForeColor = Color.White;

            foreach (Control control in form.Controls)
            {
                if (control is MenuStrip menuStrip)
                {
                    menuStrip.BackColor = Color.FromArgb(30, 30, 30);
                    menuStrip.ForeColor = Color.White;
                }
                else if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(60, 60, 60);
                    button.ForeColor = Color.White;
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.BackgroundColor = Color.FromArgb(30, 30, 30);
                    dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                    dataGridView.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            IsDarkTheme = true;
        }

        // Применить текущую тему ко всем формам приложения
        public static void ApplyThemeToAllForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (IsDarkTheme)
                    ApplyDarkTheme(form);
                else
                    ApplyLightTheme(form);
            }
        }
    }
}
