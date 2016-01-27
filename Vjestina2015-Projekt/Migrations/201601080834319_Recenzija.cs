namespace Vjestina2015_Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recenzija : DbMigration
    {

        public override void Up()
        {
            AddColumn("dbo.Recenzijas", "Tvrtka", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recenzijas", "Tvrtka");
        }
    }
}
