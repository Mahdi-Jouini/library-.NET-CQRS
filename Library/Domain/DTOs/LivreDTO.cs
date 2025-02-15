using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.DTOs
{
    public class LivreDTO
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Nom { get; set; }
        public string Auteur { get; set; }
        public DateTime DateEdition { get; set; }
        public Categorie Categorie { get; set; }

    }
}
