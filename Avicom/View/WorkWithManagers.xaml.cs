using System.Windows;
using Avicom.ViewModel;

namespace Avicom.View
{
    /// <summary>
    /// Логика взаимодействия для WorkWithManagers.xaml
    /// </summary>
    public partial class WorkWithManagers : Window
    {
        public WorkWithManagers()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();

        }
    }
}
