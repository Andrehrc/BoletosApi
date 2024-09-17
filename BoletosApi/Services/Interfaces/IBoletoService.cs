using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;

namespace BoletosApi.Services.Interfaces
{
    public interface IBoletoService
    {
        Task<BoletoDto> ObterBoleto(string boletoId);
        Task<Boleto> CadastrarBoleto(BoletoRequest boletoObj);
    }
}
