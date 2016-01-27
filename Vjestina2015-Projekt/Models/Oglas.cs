using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Vjestina2015_Projekt.Models
{
    public class Oglas
    {
        public int OglasID { get; set; }
        public string Naslov { get; set; }
        public string Tvrtka { get; set; }

        [DataType(DataType.MultilineText)]
        public string Tekst { get; set; }
        public decimal Placa { get; set; }
        public string Korisnik { get; set; }
        public virtual ICollection<Oznaka> Oznake { get; set; }
    }
}