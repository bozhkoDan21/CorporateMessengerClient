using System.IO;
using System.Windows;

namespace CorporateMessenger.Client
{
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Изначально очищаем все статусные сообщения
            StatusTextBlock.Text = "";
        }

        // Обработчик кнопки "Войти"
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Сначала очищаем сообщения
            StatusTextBlock.Text = "";

            // Проверяем, пустые ли поля
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                StatusTextBlock.Text = "Введите логин и пароль!";
            }
            else if (string.IsNullOrWhiteSpace(username))
            {
                StatusTextBlock.Text = "Введите логин!";
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                StatusTextBlock.Text = "Введите пароль!";
            }
            else
            {
                // Логика авторизации
                if (AuthenticateUser(username, password))
                {
                    OpenMainWindow();
                }
                else
                {
                    LogFailedLogin(username);
                    StatusTextBlock.Text = "Ошибка: неверный логин или пароль.";
                    txtPassword.Clear();  // Очищаем поле пароля при ошибке
                }
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Пример проверки пользователя
            return username == "admin" && password == "admin123";
        }

        private void LogFailedLogin(string username)
        {
            string logPath = "login_attempts.log";
            string logEntry = $"{DateTime.Now}: Неудачная попытка входа - {username}";
            File.AppendAllText(logPath, logEntry + Environment.NewLine);
        }

        private void OpenMainWindow()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close(); 
        }
    }
}
