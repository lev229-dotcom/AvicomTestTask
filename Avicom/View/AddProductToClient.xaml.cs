using Avicom.Model;
using Avicom.ViewModel;
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

namespace Avicom.View
{
    /// <summary>
    /// Логика взаимодействия для AddProductToClient.xaml
    /// </summary>
    public partial class AddProductToClient : Window
    {
        public BuyedProducts BuyedProducts { get; private set; }

        ComboBoxesViewModel vm;
        public AddProductToClient(BuyedProducts buyedProducts)
        {
            InitializeComponent();
            vm = new ComboBoxesViewModel();

            BuyedProducts = buyedProducts;
            this.DataContext = BuyedProducts;

            this.ProductsComboBox.ItemsSource = vm.ProductsList;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
