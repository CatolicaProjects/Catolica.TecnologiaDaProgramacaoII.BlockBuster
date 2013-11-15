namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ator : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Ator",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nome = c.String(nullable: false, maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ators");
        }
    }
}
