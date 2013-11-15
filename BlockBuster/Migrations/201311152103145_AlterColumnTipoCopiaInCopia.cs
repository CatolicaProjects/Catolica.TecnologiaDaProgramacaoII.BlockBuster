namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnTipoCopiaInCopia : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Copia", "TipoCopia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Copia", "TipoCopia", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
