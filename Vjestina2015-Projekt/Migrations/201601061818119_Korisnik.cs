namespace Vjestina2015_Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Korisnik : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oglas", "Korisnik", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oglas", "Korisnik");
        }
    }
}
