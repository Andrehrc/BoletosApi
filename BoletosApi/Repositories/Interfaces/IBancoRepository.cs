using BoletosApi.Models.Models;

namespace BoletosApi.Repositories.Interfaces
{
    public interface IBancoRepository
    {
        Task<List<Banco>> ObterBancos();

        Task<Banco> ObterBancoPorCodigo(string codigo);

        Task CadastrarBanco(Banco bancoObj);
    }
}
