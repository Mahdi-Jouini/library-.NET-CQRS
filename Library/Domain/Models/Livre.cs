using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Livre
    {
        [Key]
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Nom { get; set; }
        public string Auteur { get; set; }
        public DateTime DateEdition { get; set; }

        // Foreign key to Categorie
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
