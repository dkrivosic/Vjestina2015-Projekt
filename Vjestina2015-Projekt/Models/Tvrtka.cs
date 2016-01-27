using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vjestina2015_Projekt.Models
{
    public class Tvrtka
    {
        public int TvrtkaID { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Recenzija> Recenzije { get; set; }

    }
}