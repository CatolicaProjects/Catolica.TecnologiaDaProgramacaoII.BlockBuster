using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BlockBuster.Models
{
    public class Repository : DbContext
    {
        public Repository()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<TipoTitulo> TipoTitulos { get; set; }
        public DbSet<Copia> Copias { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<TipoCopia> TipoCopias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Titulo>()
                .HasMany(c => c.Generos).WithMany(i => i.Titulos);

            modelBuilder.Entity<Titulo>()
                .HasMany(c => c.Atores).WithMany(i => i.Titulos);

        }
    }
}