using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Avicom.Model;
using Avicom.View;

namespace Avicom.ViewModel
{
    public class ManagersClientListViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;

        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;

        IEnumerable<Client> managersClient;
        IEnumerable<Manager> managerList;

        public IEnumerable<Client> ManagersClient
        {
            get { return managersClient; }
            set
            {
                managersClient = value;
                OnPropertyChanged("ManagersClient");
            }
        } 
        public IEnumerable<Manager> ManagerList
        {
            get { return managerList; }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }

        public ManagersClientListViewModel(Manager manager)
        {
            db = new ApplicationContext();
            db.Client.Where(x => x.Manager.ID_Manager == manager.ID_Manager).Load();
            ManagersClient = db.Client.Local.ToBindingList();
        }

        /// <summary>
        /// Команда добавления
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand (obj => 
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
                      db.Client.Remove(сlient);
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
