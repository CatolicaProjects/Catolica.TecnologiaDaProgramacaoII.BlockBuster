namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTipoCopia : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.TipoCopia",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Descricao = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoCopia");
        }
    }
}