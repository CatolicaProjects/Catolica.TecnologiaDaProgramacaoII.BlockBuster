namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genero_Titulo_TipoTitulo : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Titulo",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nome = c.String(nullable: false, maxLength: 200),
            //            Sinopse = c.String(nullable: false),
            //            OrigemTitulo = c.String(nullable: false, maxLength: 100),
            //            Ano = c.Short(nullable: false),
            //            TipoTitulo_Id = c.Long(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.TipoTitulo", t => t.TipoTitulo_Id)
            //    .Index(t => t.TipoTitulo_Id);
            
            //CreateTable(
            //    "dbo.TipoTitulo",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Descricao = c.String(nullable: false, maxLength: 50),
            //            Creditos = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.TituloGenero",
            //    c => new
            //        {
            //            Titulo_Id = c.Long(nullable: false),
            //            Genero_Id = c.Long(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Titulo_Id, t.Genero_Id })
            //    .ForeignKey("dbo.Titulo", t => t.Titulo_Id, cascadeDelete: true)
            //    .ForeignKey("dbo.Genero", t => t.Genero_Id, cascadeDelete: true)
            //    .Index(t => t.Titulo_Id)
            //    .Index(t => t.Genero_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TituloGenero", new[] { "Genero_Id" });
            DropIndex("dbo.TituloGenero", new[] { "Titulo_Id" });
            DropIndex("dbo.Titulo", new[] { "TipoTitulo_Id" });
            DropForeignKey("dbo.TituloGenero", "Genero_Id", "dbo.Genero");
            DropForeignKey("dbo.TituloGenero", "Titulo_Id", "dbo.Titulo");
            DropForeignKey("dbo.Titulo", "TipoTitulo_Id", "dbo.TipoTitulo");
            DropTable("dbo.TituloGenero");
            DropTable("dbo.TipoTitulo");
            DropTable("dbo.Titulo");
        }
    }
}
