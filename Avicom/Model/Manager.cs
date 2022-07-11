using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avicom
{
    public class Manager : INotifyPropertyChanged
    {
        private int id_manager;
        private string name;
        private List<Client> clients;

        [Key]
        [Column("ID_Manager")]
        public int ID_Manager //сделать как обычный геттер сеттер
        {
            get { return id_manager; }
            set
            {
                id_manager = value;
                OnPropertyChanged("ID_Manager");
            }

        }


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
        public List<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
