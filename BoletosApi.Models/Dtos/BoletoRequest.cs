using BoletosApi.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosApi.Models.Dtos
{
    public class BoletoRequest
    {
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }
    }
}
