using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletosApi.Models.Models
{
    public class Boleto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(100), Column("nome_pagador")]
        [Required(ErrorMessage = "O nome do pagador é obrigatório.")]
        public string NomePagador { get; set; }

        [MaxLength(30), Column("cpf_cnpj_pagador")]
        [Required(ErrorMessage = "O CPF/CNPJ do pagador é obrigatório.")]
        public string CpfCnpjPagador { get; set; }

        [MaxLength(100), Column("nome_beneficiario")]
        [Required(ErrorMessage = "O nome do beneficiário é obrigatório.")]
        public string NomeBeneficiario { get; set; }

        [MaxLength(30), Column("cpf_cnpj_beneficiario")]
        [Required(ErrorMessage = "O CPF/CNPJ do beneficiário é obrigatório.")]
        public string CpfCnpjBeneficiario { get; set; }

        [Precision(10, 2), Column("valor")]
        [Required(ErrorMessage = "O valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Column("data_vencimento")]
        [Required(ErrorMessage = "A data de vencimento é obrigatória.")]
        public DateTime DataVencimento { get; set; }

        [MaxLength(500), Column("descricao")]
        public string? Observacao { get; set; }

        [ForeignKey(nameof(Banco))]
        [Required(ErrorMessage = "O BancoId é obrigatório.")]
        public int BancoId { get; set; }
    }

    public static class DbContextBoletos
    {
        public static void ConfigBoletos(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleto>(
            mb =>
            {
                mb.HasOne<Banco>()
                .WithMany()
                .HasForeignKey(x => x.BancoId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
