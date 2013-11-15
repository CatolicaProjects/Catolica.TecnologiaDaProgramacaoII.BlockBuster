namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Cliente",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nome = c.String(nullable: false, maxLength: 100),
            //            Sexo = c.String(nullable: false, maxLength: 1),
            //            DataNascimento = c.DateTime(nullable: false),
            //            Rua = c.String(maxLength: 100),
            //            Numero = c.Int(nullable: false),
            //            Bairro = c.String(maxLength: 50),
            //            Complemento = c.String(maxLength: 100),
            //            Cidade = c.String(maxLength: 100),
            //            Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
