using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlockBuster.Models
{
    public class Locacao
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [UIHint("ClienteDropDownList")]
        public int ClienteId { get; set; }
        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }

        [Required]
        [UIHint("CopiaDropDownList")]
        [Display(Name = "Cópia")]
        public int CopiaId { get; set; }
        public virtual Copia Copia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLocacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDevolucao { get; set; }
    }
}