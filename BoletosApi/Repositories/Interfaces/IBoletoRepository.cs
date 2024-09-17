using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;

namespace BoletosApi.Repositories.Interfaces
{
    public interface IBoletoRepository
    {
        Task<BoletoDto> ObterBoleto(string boletoId);
        Task<Boleto> CadastrarBoleto(Boleto boletoObj);

    }
}
