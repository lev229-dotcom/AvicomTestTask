using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Avicom.View;
using Avicom.Model;
using System;
using System.Windows;

namespace Avicom.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        readonly ApplicationContext db;

        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;
        private RelayCommand managersClientCommand;
        IEnumerable<Manager> managers;
        public IEnumerable<Manager> Managers
        {
            get { return managers; }
            set
            {
                managers = value;
                OnPropertyChanged("Managers");
            }
        }


        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Manager.Load();
            Managers = db.Manager.Local.ToBindingList();
            


        }
        /// <summary>
        /// команда добавления
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand (obj => 
                    {
                        ManagerWindow managerWindow = new ManagerWindow(new Manager());
                        if (managerWindow.ShowDialog() == true)
                        {
                            Manager manager = managerWindow.Manager; ;
                            db.Manager.Add(manager);
                            db.SaveChanges();
                        }
                     }));
            }
        }
        /// <summary>
        /// команда редактирования
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
                      Manager manager = selectedItem as Manager;

                      Manager vm = new Manager()
                      {
                         ID_Manager = manager.ID_Manager,
                         Name = manager.Name
                      };
                      ManagerWindow managerWindow = new ManagerWindow(vm);


                      if (managerWindow.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          manager = db.Manager.Find(managerWindow.Manager.ID_Manager);
                          if (manager != null)
                          {
                              manager.Name = managerWindow.Manager.Name;
                              db.Entry(manager).CurrentValues.SetValues(managerWindow.Manager);//selectedItem 
                              db.SaveChanges();
                          }
                      }
                  }, o => o != null));
            }
        }

        /// <summary>
        /// Переход к окну со списком клиентов менеджера
        /// </summary>
        public RelayCommand ManagersClientCommand
        {
            get
            {
                return managersClientCommand ??
                  (managersClientCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Manager manager = selectedItem as Manager;

                      Manager vm = new Manager()
                      {
                          ID_Manager = manager.ID_Manager,
                          Name = manager.Name,
                          Clients = manager.Clients
                          
                      };
                      ManagersClientLisr managerWindow = new ManagersClientLisr(vm);
                      managerWindow.ShowDialog();
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
                      Manager manager = selectedItem as Manager;
                      try
                      {
                          db.Manager.Remove(manager);
                          db.SaveChanges();
                      }
                      catch(Exception )
                      {
                      }
                  }, o => o != null));
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
