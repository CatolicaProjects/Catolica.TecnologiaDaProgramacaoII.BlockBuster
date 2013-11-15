using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlockBuster.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [StringLength(100)]
        public string Rua { get; set; }

        public int Numero { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        [StringLength(100)]
        public string Complemento { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Saldo { get; set; }

        public virtual ICollection<Locacao> Locacoes { get; set; }
    }
}