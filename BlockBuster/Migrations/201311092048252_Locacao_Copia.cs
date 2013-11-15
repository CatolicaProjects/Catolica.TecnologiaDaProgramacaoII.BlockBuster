namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Locacao_Copia : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Copia",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            TipoCopia = c.String(nullable: false, maxLength: 2),
            //            Titulo_Id = c.Long(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Titulo", t => t.Titulo_Id)
            //    .Index(t => t.Titulo_Id);
            
            //CreateTable(
            //    "dbo.Locacao",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            DataLocacao = c.DateTime(nullable: false),
            //            DataDevolucao = c.DateTime(nullable: false),
            //            Cliente_Id = c.Long(),
            //            Copia_Id = c.Long(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
            //    .ForeignKey("dbo.Copia", t => t.Copia_Id)
            //    .Index(t => t.Cliente_Id)
            //    .Index(t => t.Copia_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locacao", new[] { "Copia_Id" });
            DropIndex("dbo.Locacao", new[] { "Cliente_Id" });
            DropIndex("dbo.Copia", new[] { "Titulo_Id" });
            DropForeignKey("dbo.Locacao", "Copia_Id", "dbo.Copia");
            DropForeignKey("dbo.Locacao", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Copia", "Titulo_Id", "dbo.Titulo");
            DropTable("dbo.Locacao");
            DropTable("dbo.Copia");
        }
    }
}
