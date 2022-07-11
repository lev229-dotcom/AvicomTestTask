using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Avicom.Model;
using Avicom.View;
using System.Windows;
using System;

namespace Avicom.ViewModel
{
    public class ClientProductsViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;

        int Client_ID;

        private RelayCommand addCommand;
        private RelayCommand deleteCommand;

        IEnumerable<Product> buyedProducts;

        public IEnumerable<Product> BuyedProducts
        {
            get { return buyedProducts; }
            set 
            { 
                buyedProducts = value; 
                OnPropertyChanged("BuyedProducts");
            }
        }

        public ClientProductsViewModel(Client client)
        {
            db = new ApplicationContext();

            Update(client.ID_Client);
            Client_ID = client.ID_Client;
        }

        void Update(int ID)
        {
            db.Product.Join(db.BuyedProducts,
                           product => product.ID_Product,
                           buyedproducts => buyedproducts.Product_ID,
                           (product, buyedproducts) => new { product, buyedproducts })
                           .Join(db.Client,
                           buyedproducts2 => buyedproducts2.buyedproducts.Client_ID,
                           c => c.ID_Client,
                           (buyedproducts2, c) => new { buyedproducts2, c })
                           .Where(r => r.buyedproducts2.buyedproducts.Client_ID == ID)
                           .Select(x => x.buyedproducts2.buyedproducts.Product)
                           .Load();

            BuyedProducts = db.Product.Local.ToBindingList();
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
                        AddProductToClient productToClientWindow = new AddProductToClient(new BuyedProducts());
                        if (productToClientWindow.ShowDialog() == true)
                        {
                            try
                            {
                                BuyedProducts product = productToClientWindow.BuyedProducts;
                                product.Client_ID = Client_ID;
                                db.BuyedProducts.Add(product);
                                db.SaveChanges();
                                Update(Client_ID);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Произошла ошибка");
                            }
                           
                        }
                    }));
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

                      BuyedProducts buyedProducts = db.BuyedProducts.Where(x => x.Product_ID == product.ID_Product
                      && x.Client_ID == Client_ID).First();

                      db.BuyedProducts.Remove(buyedProducts);
                      db.SaveChanges();

                      BuyedProducts = db.Product.Local.ToBindingList();
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
