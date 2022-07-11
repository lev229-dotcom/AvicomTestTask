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
    /// Логика взаимодействия для CustomerProducts.xaml
    /// </summary>
    public partial class ClientProducts : Window
    {
        public ClientProducts(Client client)
        {
            InitializeComponent();
            DataContext = new ClientProductsViewModel(client);

        }
    }
}
