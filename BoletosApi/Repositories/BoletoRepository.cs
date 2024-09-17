using BoletosApi.Context;
using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;
using BoletosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoletosApi.Repositories;

public class BoletoRepository : IBoletoRepository
{
    private readonly ApplicationDbContext _context;

    public BoletoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BoletoDto> ObterBoleto(string boletoId)
    {
        var result = await (from boleto in _context.Boletos
                            join bancos in _context.Bancos on boleto.BancoId equals bancos.Id
                            where boleto.Id == boletoId
                            select new BoletoDto()
                            {
                                NomePagador = boleto.NomePagador,
                                CpfCnpjPagador = boleto.CpfCnpjPagador,
                                NomeBeneficiario = boleto.NomeBeneficiario,
                                CpfCnpjBeneficiario = boleto.CpfCnpjBeneficiario,
                                Valor = boleto.Valor,
                                DataVencimento = boleto.DataVencimento,
                                Observacao = boleto.Observacao,
                                Banco = bancos.Nome,
                                Juros = bancos.Juros
                            }).FirstOrDefaultAsync();

        return result;
    }

    public async Task<Boleto> CadastrarBoleto (Boleto boletoObj)
    {
        await _context.Boletos.AddAsync(boletoObj);
        await _context.SaveChangesAsync();

        return boletoObj;
    }
}
