using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vjestina2015_Projekt.Models
{
    public class Recenzija
    {
        public int RecenzijaID { get; set; }
        public string Tvrtka { get; set; }
        public string Korisnik { get; set; }
        public string Naslov { get; set; }

        [Range(1, 5)]
        public int Ocjena { get; set; }
        public string Tekst { get; set; }

    }
}