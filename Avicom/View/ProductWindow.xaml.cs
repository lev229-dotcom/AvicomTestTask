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
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public Product Product { get; private set; }
        ComboBoxesViewModel vm;
        public ProductWindow(Product product)
        {
            InitializeComponent();
            vm = new ComboBoxesViewModel();
            Product = product;
            this.DataContext = Product;

            //this.TypeComboBox.DataContext = vm;
            this.TypeComboBox.ItemsSource = vm.TypeList;

            //this.TypeComboBox1.DataContext = vm;
            this.TypeComboBox1.ItemsSource = vm.SubPeriodList;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
