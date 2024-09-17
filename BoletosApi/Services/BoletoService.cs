using AutoMapper;
using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;
using BoletosApi.Repositories.Interfaces;
using BoletosApi.Services.Interfaces;

namespace BoletosApi.Services;

public class BoletoService : IBoletoService
{
    private readonly IBoletoRepository _boletoRepository;
    private readonly IMapper _mapper;

    public BoletoService(IBoletoRepository boletoRepository, IMapper mapper)
    {
        _boletoRepository = boletoRepository;
        _mapper = mapper;
    }

    public async Task<BoletoDto> ObterBoleto(string boletoId)
    {
        var result = await _boletoRepository.ObterBoleto(boletoId);

        if (result == null)
        {
            return null;
        }

        if (result.DataVencimento < DateTime.Now.Date)
        {
            var juros = result.Juros / 100;
            var valorAdicional = result.Valor * juros;
            result.Valor = result.Valor + valorAdicional;
        }
        else
        {
            result.Juros = 0;
        }

        return result;
    }

    public async Task<Boleto> CadastrarBoleto(BoletoRequest boletoObj)
    {
        var mappedBoleto = _mapper.Map<Boleto>(boletoObj);

        return await _boletoRepository.CadastrarBoleto(mappedBoleto);
    }

}
