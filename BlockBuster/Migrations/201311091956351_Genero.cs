namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genero : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Genero",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Descricao = c.String(nullable: false, maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Genero");
        }
    }
}
