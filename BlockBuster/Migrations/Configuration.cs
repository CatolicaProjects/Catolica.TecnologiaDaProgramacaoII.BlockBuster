namespace BlockBuster.Migrations
{
    using BlockBuster.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlockBuster.Models.Repository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlockBuster.Models.Repository context)
        {
            context.TipoCopias.AddOrUpdate(
                p => p.Descricao,
                new TipoCopia { Descricao = "CDRom" },
                new TipoCopia { Descricao = "DVD" },
                new TipoCopia { Descricao = "Blue Ray" },
                new TipoCopia { Descricao = "VHS" }
                );
        }
    }
}
