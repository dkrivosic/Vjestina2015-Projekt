namespace Vjestina2015_Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OznakaEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oznakas", "Oglas_OglasID", c => c.Int());
            CreateIndex("dbo.Oznakas", "Oglas_OglasID");
            AddForeignKey("dbo.Oznakas", "Oglas_OglasID", "dbo.Oglas", "OglasID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oznakas", "Oglas_OglasID", "dbo.Oglas");
            DropIndex("dbo.Oznakas", new[] { "Oglas_OglasID" });
            DropColumn("dbo.Oznakas", "Oglas_OglasID");
        }
    }
}
