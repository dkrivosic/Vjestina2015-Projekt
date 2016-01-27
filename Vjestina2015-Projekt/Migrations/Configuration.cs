namespace Vjestina2015_Projekt.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Vjestina2015_Projekt.DAL.PrakseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vjestina2015_Projekt.DAL.PrakseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Oznaka java = new Oznaka { Naziv = "Java" };
            Oznaka net = new Oznaka { Naziv = ".NET" };
            Oznaka js = new Oznaka { Naziv = "Javascript" };
            Oznaka scala = new Oznaka { Naziv = "Scala" };
            Oznaka ruby = new Oznaka { Naziv = "Ruby" };

            context.Oznake.AddOrUpdate(o => o.Naziv,
                java, net, js, scala, ruby
            );

            context.Tvrtke.AddOrUpdate(t => t.Ime,
                new Tvrtka { TvrtkaID = 1, Ime = "Google", Opis = "google.com" },
                new Tvrtka { TvrtkaID = 2, Ime = "Microsoft", Opis = "Proizvodimo windowse" },
                new Tvrtka { TvrtkaID = 3, Ime = "Facebook", Opis = "fejs" }
            );

            context.Oglasi.AddOrUpdate(o => o.OglasID,
                new Oglas { Naslov = "Java programer", Tvrtka = "Google", Placa = 30, Tekst = "Trazimo java programera za rad na google trazilici", Korisnik = "Domi" , Oznake = new List<Oznaka> { java, scala, js } },
                new Oglas { Naslov = ".NET programer", Tvrtka = "Microsoft", Placa = 31, Tekst = "Trazimo .NET programera koji ce raditi na novim proizvodima", Korisnik = "Bill Gates", Oznake = new List<Oznaka> { net, js } }
            );

            context.Recenzije.AddOrUpdate(r => r.RecenzijaID,
                new Vjestina2015_Projekt.Models.Recenzija { Tvrtka = "Google", Korisnik = "Domi", Naslov = "Jaako Dobro", Ocjena = 5, Tekst = "Super firma, jako zanimljivo itd....."}
                );

        }
    }
}
