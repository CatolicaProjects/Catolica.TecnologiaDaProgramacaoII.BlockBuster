using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlockBuster.Models
{
    public class Titulo
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        public string Sinopse { get; set; }

        [Required]
        [StringLength(100)]
        public string OrigemTitulo { get; set; }

        [Required]
        public short Ano { get; set; }

        [Required]
        [UIHint("TipoTituloDropDownList")]
        public int TipoTituloId { get; set; }
        public virtual TipoTitulo TipoTitulo { get; set; }

        public virtual ICollection<Genero> Generos { get; set; }

        public virtual ICollection<Ator> Atores { get; set; }

        public virtual ICollection<Copia> Copias { get; set; }
    }
}