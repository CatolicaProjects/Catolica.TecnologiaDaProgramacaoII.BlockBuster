namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TituloAtor : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.TituloAtor",
            //    c => new
            //        {
            //            Titulo_Id = c.Long(nullable: false),
            //            Ator_Id = c.Long(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Titulo_Id, t.Ator_Id })
            //    .ForeignKey("dbo.Titulo", t => t.Titulo_Id, cascadeDelete: true)
            //    .ForeignKey("dbo.Ator", t => t.Ator_Id, cascadeDelete: true)
            //    .Index(t => t.Titulo_Id)
            //    .Index(t => t.Ator_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TituloAtor", new[] { "Ator_Id" });
            DropIndex("dbo.TituloAtor", new[] { "Titulo_Id" });
            DropForeignKey("dbo.TituloAtor", "Ator_Id", "dbo.Ator");
            DropForeignKey("dbo.TituloAtor", "Titulo_Id", "dbo.Titulo");
            DropTable("dbo.TituloAtor");
        }
    }
}
