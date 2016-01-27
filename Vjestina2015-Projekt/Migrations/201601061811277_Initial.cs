namespace Vjestina2015_Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oglas",
                c => new
                    {
                        OglasID = c.Int(nullable: false, identity: true),
                        Naslov = c.String(),
                        Tvrtka = c.String(),
                        Tekst = c.String(),
                        Placa = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OglasID);
            
            CreateTable(
                "dbo.Oznakas",
                c => new
                    {
                        OznakaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Oglas_OglasID = c.Int(),
                    })
                .PrimaryKey(t => t.OznakaID)
                .ForeignKey("dbo.Oglas", t => t.Oglas_OglasID)
                .Index(t => t.Oglas_OglasID);
            
            CreateTable(
                "dbo.Recenzijas",
                c => new
                    {
                        RecenzijaID = c.Int(nullable: false, identity: true),
                        Korisnik = c.String(),
                        Naslov = c.String(),
                        Ocjena = c.Int(nullable: false),
                        Tekst = c.String(),
                        Tvrtka_TvrtkaID = c.Int(),
                    })
                .PrimaryKey(t => t.RecenzijaID)
                .ForeignKey("dbo.Tvrtkas", t => t.Tvrtka_TvrtkaID)
                .Index(t => t.Tvrtka_TvrtkaID);
            
            CreateTable(
                "dbo.Tvrtkas",
                c => new
                    {
                        TvrtkaID = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.TvrtkaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recenzijas", "Tvrtka_TvrtkaID", "dbo.Tvrtkas");
            DropForeignKey("dbo.Oznakas", "Oglas_OglasID", "dbo.Oglas");
            DropIndex("dbo.Recenzijas", new[] { "Tvrtka_TvrtkaID" });
            DropIndex("dbo.Oznakas", new[] { "Oglas_OglasID" });
            DropTable("dbo.Tvrtkas");
            DropTable("dbo.Recenzijas");
            DropTable("dbo.Oznakas");
            DropTable("dbo.Oglas");
        }
    }
}
