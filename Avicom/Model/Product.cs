using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Avicom.Model;

namespace Avicom
{
    public class Product : INotifyPropertyChanged
    {
        private int id_product;
        private string name;
        private decimal price;
        private string type;
        private string subPeriod;
        private ICollection<BuyedProducts> buyedproducts;

        [Key]
        public int ID_Product
        {
            get { return id_product; }
            set
            {
                id_product = value;
                OnPropertyChanged("ID_Product");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public decimal Price 
        { 
            get { return price; }
            set 
            { 
                price = value; 
                OnPropertyChanged("Price"); 
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public string SubPeriod
        {
            get { return subPeriod; }
            set
            {
                subPeriod = value;
                OnPropertyChanged("SubPeriod");
            }
        }

        public ICollection<BuyedProducts> BuyedProducts
        {
            get { return buyedproducts; }
            set
            {
                buyedproducts = value;
                OnPropertyChanged("BuyedProducts");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
