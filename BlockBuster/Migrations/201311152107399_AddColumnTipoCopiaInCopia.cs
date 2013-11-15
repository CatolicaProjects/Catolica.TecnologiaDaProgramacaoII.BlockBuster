namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTipoCopiaInCopia : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Copia", "TipoCopiaId", c => c.Int(nullable: false));
            
            
            //AddForeignKey("dbo.Copia", "TipoCopiaId", "dbo.TipoCopia", "Id", cascadeDelete: true);



            //CreateIndex("dbo.Copia", "TipoCopiaId");
        }

        public override void Down()
        {
            DropIndex("dbo.Copia", new[] { "TipoCopiaId" });
            DropForeignKey("dbo.Copia", "TipoCopiaId", "dbo.TipoCopia");
            DropColumn("dbo.Copia", "TipoCopiaId");
        }
    }
}
