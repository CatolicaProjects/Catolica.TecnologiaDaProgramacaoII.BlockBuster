using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlockBuster.Models
{
    public class Copia
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]        
        public long Id { get; set; }

        [Required]
        [UIHint("TituloDropDownList")]
        public int TituloId { get; set; }
        public virtual Titulo Titulo { get; set; }

        [Required]
        [UIHint("TipoCopiaDropDownList")]
        public int TipoCopiaId { get; set; }
        public virtual TipoCopia TipoCopia { get; set; }

        public virtual ICollection<Locacao> Locacoes { get; set; }
    }  
}