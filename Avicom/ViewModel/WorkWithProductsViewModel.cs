using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Avicom.View;
using Avicom.Model;
using System.Windows;
using System;

namespace Avicom.ViewModel
{
    public class WorkWithProductsViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;

        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;

        IEnumerable<Product> products;

        public static List<string> _Type = new List<string>() { "Подписка", "Постноянная лицензия" };
        
       
        public List<string> Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }

        public IEnumerable<Product> Products
        {
            get { return products; }
            set 
            { 
                products = value;
                OnPropertyChanged("Products");
            }
        }

        public WorkWithProductsViewModel()
        {
            db = new ApplicationContext();
            db.Product.Load();
            Products = db.Product.Local.ToBindingList();

            Type = _Type;
        }

        /// <summary>
        /// Команда добавления
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        ProductWindow productWindow = new ProductWindow(new Product());
                        if (productWindow.ShowDialog() == true)
                        {
                            Product product = productWindow.Product;
                            if (product.Type == "Постоянная лицензия" && product.SubPeriod != "Нет")
                                MessageBox.Show("У лицензии не может периода подписки");
                            else
                            {
                                try
                                {
                                    db.Product.Add(product);
                                    db.SaveChanges();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Произошла ошибка");

                                }
                               
                            }                           
                        }



                    }));
            }
        }

        /// <summary>
        /// Команда редактирования
        /// </summary>
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Product product = selectedItem as Product;

                      Product vm = new Product()
                      {
                          ID_Product = product.ID_Product,
                          Name = product.Name,
                          Price = product.Price,
                          Type = product.Type,
                          SubPeriod = product.SubPeriod
                      };
                      ProductWindow productWindow = new ProductWindow(vm);


                      if (productWindow.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          product = db.Product.Find(productWindow.Product.ID_Product);
                          if (product != null)
                          {
                              if (productWindow.Product.Type == "Постоянная лицензия" && productWindow.Product.SubPeriod != "Нет")
                                  MessageBox.Show("У лицензии не может периода подписки");
                              else
                              {
                                  product.Name = productWindow.Product.Name;
                                  product.Price = productWindow.Product.Price;
                                  product.Type = productWindow.Product.Type;
                                  product.SubPeriod = productWindow.Product.SubPeriod;

                                  db.Entry(product).CurrentValues.SetValues(productWindow.Product);//selectedItem 
                                  db.SaveChanges();
                              }
                              
                          }
                      }
                  }, o => o != null));
            }
        }
        /// <summary>
        /// Команда удаления
        /// </summary>
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Product product = selectedItem as Product;
                      db.Product.Remove(product);
                      db.SaveChanges();
                  }, o => o != null));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
