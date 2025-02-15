using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }

        // Foreign key to Livre
        public string LivreISBN { get; set; }
        public Livre Livre { get; set; }

        // Foreign key to Emprunteur
        public string EmprunteurNumero { get; set; }
        public Emprunteur Emprunteur { get; set; }
    }
}
