using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosApi.Models.Models
{
    public class Banco
    {
        public int Id { get; set; }

        [MaxLength(100), Column("nome")]
        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(50), Column("codigo")]
        [Required(ErrorMessage = "O código do banco é obrigatório.")]
        public string Codigo { get; set; }

        [Precision(5, 2), Column("juros")]
        [Required(ErrorMessage = "A taxa de juros é obrigatória.")]
        public decimal Juros { get; set; }
    }
}
