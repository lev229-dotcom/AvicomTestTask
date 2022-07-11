using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avicom
{
    public class ClientStatus
    {
        [Key]
        public string Status { get; set; }
        public List<Client> Clients { get; set; }

    }
}
