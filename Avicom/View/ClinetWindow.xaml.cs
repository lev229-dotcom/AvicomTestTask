using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Avicom.ViewModel;

namespace Avicom.View
{
    /// <summary>
    /// Логика взаимодействия для ClinetWindow.xaml
    /// </summary>
    public partial class ClinetWindow : Window
    {
        public Client Client { get; private set; }

        ComboBoxesViewModel vm;
        public ClinetWindow(Client client)
        {
            InitializeComponent();
            vm = new ComboBoxesViewModel();
            Client = client;
            this.DataContext = Client;
            this.ClientSatusComboBox.ItemsSource = vm.ClientStatusList;
            this.ManagerComboBox.ItemsSource = vm.ManagerList;
        }

       
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
