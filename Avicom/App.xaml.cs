using System.Windows;
using Avicom.View;

namespace Avicom
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            MainWindow window = new MainWindow();


            window.Show();
        }
    }
}
