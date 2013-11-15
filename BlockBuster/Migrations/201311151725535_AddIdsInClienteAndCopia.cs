namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdsInClienteAndCopia : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Locacao", "ClienteId", c => c.Int(nullable: false));
            //AddColumn("dbo.Locacao", "CopiaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locacao", "CopiaId");
            DropColumn("dbo.Locacao", "ClienteId");
        }
    }
}
