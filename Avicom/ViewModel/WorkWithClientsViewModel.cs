using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Avicom.View;
using Avicom.Model;
using System;

namespace Avicom.ViewModel
{
    public class WorkWithClientsViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;

        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;
        private RelayCommand clientProductsCommand;

        private RelayCommand showAllCommand;
        private RelayCommand showCommonCommand;
        private RelayCommand showVipCommand;


        IEnumerable<Client> clients;


        public IEnumerable<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }



        public WorkWithClientsViewModel()
        {
            db = new ApplicationContext();
            db.Client.Load();
            Clients = db.Client.Local.ToBindingList();
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
                        ClinetWindow clientWindow = new ClinetWindow(new Client());
                        if (clientWindow.ShowDialog() == true)
                        {
                            Client client = clientWindow.Client;
                            //client.Manager_ID = ManagerID;
                            db.Client.Add(client);
                            db.SaveChanges();
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
                      Client client = selectedItem as Client;

                      Client vm = new Client()
                      {
                          ID_Client = client.ID_Client,
                          Name = client.Name,
                          Status = client.Status,
                          Manager_ID = client.Manager_ID
                      };
                      ClinetWindow clientWindow = new ClinetWindow(vm);


                      if (clientWindow.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          client = db.Client.Find(clientWindow.Client.ID_Client);
                          if (client != null)
                          {
                              client.Name = clientWindow.Client.Name;
                              client.Status = clientWindow.Client.Status;
                              db.Entry(client).CurrentValues.SetValues(clientWindow.Client);//selectedItem 
                              db.SaveChanges();
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
                      Client сlient = selectedItem as Client;
                      try
                      {
                          db.Client.Remove(сlient);
                          db.SaveChanges();
                      }
                      catch(Exception)
                      {

                      }
                  }, o => o != null));
            }
        }
        /// <summary>
        /// Список товаров пользователя
        /// </summary>
        public RelayCommand ClientProductsCommand
        {
            get
            {
                return clientProductsCommand ??
                  (clientProductsCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Client client = selectedItem as Client;

                      Client vm = new Client()
                      {
                          ID_Client = client.ID_Client
                          
                      };
                      ClientProducts clientProductsWindow = new ClientProducts(vm);
                      clientProductsWindow.ShowDialog();
                  }, o => o != null));
            }
        }
        /// <summary>
        /// Список всех пользователей
        /// </summary>
        public RelayCommand ShowAllCommand
        {
            get
            {
                return showAllCommand ??
                    (showAllCommand = new RelayCommand((obj) =>
                    {
                        db = new ApplicationContext();
                        db.Client.Load();
                        Clients = db.Client.Local.ToBindingList();
                    }));
            }
        }
        /// <summary>
        /// Список обычных пользователей
        /// </summary>
        public RelayCommand ShowCommonCommand
        {
            get
            {
                return showCommonCommand ??
                    (showCommonCommand = new RelayCommand((obj) =>
                    {
                        db = new ApplicationContext();
                        db.Client.Where(x => x.Status == "Обычный клиент").Load();
                        Clients = db.Client.Local.ToBindingList();
                    }));
            }
        }
        /// <summary>
        /// Список ключевых пользователей
        /// </summary>
        public RelayCommand ShowVipCommand
        {
            get
            {
                return showVipCommand ??
                    (showVipCommand = new RelayCommand((obj) =>
                    {
                        db = new ApplicationContext();
                        db.Client.Where(x => x.Status == "Ключевой клиент").Load();
                        Clients = db.Client.Local.ToBindingList();
                    }));
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
