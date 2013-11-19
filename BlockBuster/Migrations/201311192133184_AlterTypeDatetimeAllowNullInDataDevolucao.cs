namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTypeDatetimeAllowNullInDataDevolucao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locacao", "DataDevolucao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locacao", "DataDevolucao", c => c.DateTime(nullable: false));
        }
    }
}
