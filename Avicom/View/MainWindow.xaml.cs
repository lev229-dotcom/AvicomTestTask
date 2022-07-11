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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Avicom.Model;
using Avicom.ViewModel;

namespace Avicom.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Data Source = LAPTOP - 3SOVKD2O;Initial Catalog = Classroom; Integrated Security = True
      
        public MainWindow()
        {
          
            InitializeComponent();
            DataContext = new MainMenuViewModel();
        }
        void Main()
        {
            using (var db = new ApplicationContext())
            {
                //Manager m = new Manager { Name = "Testjknnkjnkjn" };
                //Manager m2 = new Manager { Name = "иванов" };
                //BuyedProducts m3 = new BuyedProducts { Client_ID = 8, Product_ID = 3 };
                

                //db.BuyedProducts.Add(m3);
                //db.SaveChanges();

            }

           


        }
    }
}
