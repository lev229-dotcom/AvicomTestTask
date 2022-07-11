using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Avicom.View;
using Avicom.Model;

namespace Avicom.ViewModel
{
    public class MainMenuViewModel : INotifyPropertyChanged
    {
        private RelayCommand openWorkWithManagersWindowCommand;
        private RelayCommand openWorkWithClientsWindowCommand;
        private RelayCommand openWorkWithProductsWindowCommand;

        /// <summary>
        /// Переход к окну для работы с менеджерами
        /// </summary>
        public RelayCommand OpenWorkWithManagersWindowCommand
        {
            get
            {
                return openWorkWithManagersWindowCommand ??
                    (openWorkWithManagersWindowCommand = new RelayCommand(obj =>
                    {
                        WorkWithManagers managerWindow = new WorkWithManagers();
                       managerWindow.Show();
                    }));
            }
        }
        /// <summary>
        /// Переход к окну для работы с клиентами
        /// </summary>
        public RelayCommand OpenWorkWithClientsWindowCommand
        {
            get
            {
                return openWorkWithClientsWindowCommand ??
                    (openWorkWithClientsWindowCommand = new RelayCommand(obj =>
                    {
                        WorkWithClients clientWindow = new WorkWithClients();
                       clientWindow.Show();
                    }));
            }
        }
        /// <summary>
        /// Переход к окну для работы с продуктами
        /// </summary>
        public RelayCommand OpenWorkWithProductsWindowCommand
        {
            get
            {
                return openWorkWithProductsWindowCommand ??
                    (openWorkWithProductsWindowCommand = new RelayCommand(obj =>
                    {
                       WorkWithProducts productWindow = new WorkWithProducts();
                        productWindow.Show();
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
