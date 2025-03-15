using System.Windows;
using System.Windows.Media.Animation;

namespace CorporateMessenger.Client
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Запускаем анимацию логотипа и ждём её завершения
            await ShowLogoAnimation();

            // Открываем главное окно после завершения анимации
            OpenMainWindow();
        }

        private async Task ShowLogoAnimation()
        {
            // Появление логотипа (1 секунда)
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
            LogoImage.BeginAnimation(OpacityProperty, fadeIn);

            // Ждем 3 секунды, пока логотип будет виден
            await Task.Delay(3000);

            // Исчезновение логотипа (1 секунда)
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
            LogoImage.BeginAnimation(OpacityProperty, fadeOut);

            // Ждем, пока логотип исчезнет
            await Task.Delay(1000); // Задержка после исчезновения
        }

        private void OpenMainWindow()
        {
            // После завершения анимации открываем основное окно
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close(); // Закрываем SplashScreen
        }
    }
}
