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

namespace Avicom.Model
{
    public class BuyedProducts : INotifyPropertyChanged
    {
        private int client_id;
        private int product_id;
        private Client client;
        private Product product;


        public int Client_ID 
        { 
            get { return client_id; }
            set
            {
                client_id = value;
                OnPropertyChanged("Client_ID");
            }
        }
        public int Product_ID
        {
            get { return product_id; }
            set
            {
                product_id = value;
                OnPropertyChanged("Product_ID");
            }
        }
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("Client");
            }
        }
        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
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
