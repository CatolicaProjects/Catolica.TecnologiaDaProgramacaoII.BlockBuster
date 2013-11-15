namespace BlockBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnIdsInTipoTituloAndTitulo : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Titulo", "TipoTituloId", c => c.Int(nullable: false));
            //AddColumn("dbo.Copia", "TituloId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Copia", "TituloId");
            DropColumn("dbo.Titulo", "TipoTituloId");
        }
    }
}
