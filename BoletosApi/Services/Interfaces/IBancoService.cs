using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;

namespace BoletosApi.Services.Interfaces
{
    public interface IBancoService
    {
        Task<List<Banco>> ObterBancos();

        Task<Banco> ObterBancoPorCodigo(string codigo);

        Task<string> CadastrarBanco(BancoRequest bancoRequest);
    }
}
