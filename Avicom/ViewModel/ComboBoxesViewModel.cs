using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Avicom.ViewModel
{
    public class ComboBoxesViewModel : INotifyPropertyChanged
    {
        readonly ApplicationContext db;

        IEnumerable<Manager> managerList;
        IEnumerable<ClientStatus> clientstatusList;
        IEnumerable<Product> productsList;

        public static List<string> _TypeList = new List<string>() { "Подписка", "Постоянная лицензия" };
        public static List<string> _SubPeriodList = new List<string>() { "Год", "Месяц", "Квартал", "Нет" };

        private string _Type;

        public string Type
        {
            get { return _Type; }
            set
            {
                _Type = value;

                OnPropertyChanged("Type");

                OnPropertyChanged("IsSub");
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
        public IEnumerable<ClientStatus> ClientStatusList
        {
            get { return clientstatusList; }
            set
            {
                clientstatusList = value;
                OnPropertyChanged("ClientStatusList");
            }
        }
        public IEnumerable<Product> ProductsList
        {
            get { return productsList; }
            set
            {
                productsList = value;
                OnPropertyChanged("ProductsList");
            }
        }

        public  List<string> TypeList
        {
            get { return _TypeList; }
            set
            {
                _TypeList = value;
                OnPropertyChanged("TypeList");

               
            }
        }
        public  List<string> SubPeriodList
        {
            get { return _SubPeriodList; }
            set
            {
                _SubPeriodList = value;
                OnPropertyChanged("SubPeriodList");

               
            }
        }

        public bool IsSub
        {
            get { return (Type == "Подписка"); }
        }

        public ComboBoxesViewModel()
        {
            db = new ApplicationContext();
           
            db.Manager.Load();
            ManagerList = db.Manager.Local.ToBindingList();

            db.ClientStatus.Load();
            ClientStatusList = db.ClientStatus.Local.ToBindingList();

            db.Product.Load();
            ProductsList = db.Product.Local.ToBindingList();

            TypeList = _TypeList;
            SubPeriodList = _SubPeriodList;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
