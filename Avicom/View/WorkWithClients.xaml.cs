using Avicom.ViewModel;
using System.Windows;


namespace Avicom.View
{
    /// <summary>
    /// Логика взаимодействия для WorkWithClients.xaml
    /// </summary>
    public partial class WorkWithClients : Window
    {
        public WorkWithClients()
        {
            InitializeComponent();
            DataContext = new WorkWithClientsViewModel();
        }
    }
}
