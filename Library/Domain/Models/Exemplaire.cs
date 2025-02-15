using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Exemplaire
    {
        [Key]
        public string idExemplaire { get; set; }
        public string Statut { get; set; }

        // Foreign key to Livre
        public string LivreISBN { get; set; }
        public Livre Livre { get; set; }
    }
}
