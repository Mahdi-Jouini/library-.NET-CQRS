using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Emprunt
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public int Duree { get; set; }

        // Foreign key to Exemplaire
        public string NumeroExemplaire { get; set; }
        public Exemplaire Exemplaire { get; set; }

        // Foreign key to Emprunteur
        public string EmprunteurNumero { get; set; }
        public Emprunteur Emprunteur { get; set; }

    }
}
