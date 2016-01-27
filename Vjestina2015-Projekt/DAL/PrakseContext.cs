using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vjestina2015_Projekt.Models;

namespace Vjestina2015_Projekt.DAL
{
    public class PrakseContext : DbContext
    {
        public PrakseContext() : base("PrakseContext")
        {
        }

        public DbSet<Oznaka> Oznake { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }
        public DbSet<Tvrtka> Tvrtke { get; set; }
        public DbSet<Oglas> Oglasi { get; set; }

    }
}