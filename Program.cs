namespace TechStockManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK) // Если авторизация прошла успешно
            {
                string department = loginForm.UserDepartment;
                // Открываем основное окно
                Application.Run(new Form1(department));
            }

        }
    }
}