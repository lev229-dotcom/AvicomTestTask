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
    public class Client : INotifyPropertyChanged
    {
        private int id_client;
        private string name;
        private string status;
        private int manager_id;
        private ICollection<BuyedProducts> buyedproducts;


        [Key]
        [Column("ID_Client")]
        public int ID_Client 
        { 
            get { return id_client; }
            set
            {
                id_client = value;
                OnPropertyChanged("ID_Client");    
            }
        }
        
        [Required]
        [Column("Name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [Required]
        [MaxLength(15)]
        [Column("Status")]
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        [ForeignKey("Status")]
        public ClientStatus ClientStatus { get; set; }
        
        [Required]
        public int Manager_ID
        {
            get { return manager_id; }
            set
            {
                manager_id = value;
                OnPropertyChanged("Manager_ID");
            }
        }
        [ForeignKey("Manager_ID")]
        public Manager Manager { get; set; } // Свойство для навигации

        //public List<Product> Products { get; set; } = new List<Product>();
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
