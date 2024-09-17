using AutoMapper;
using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;
using BoletosApi.Repositories.Interfaces;
using BoletosApi.Services.Interfaces;

namespace BoletosApi.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _repo;
        private readonly IMapper _mapper;

        public BancoService(IBancoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<Banco>> ObterBancos()
        {
            return await _repo.ObterBancos();
        }

        public async Task<Banco> ObterBancoPorCodigo(string codigo)
        {
            return await _repo.ObterBancoPorCodigo(codigo);
        }

        public async Task<string> CadastrarBanco(BancoRequest bancoRequest)
        {
            var request = _mapper.Map<Banco>(bancoRequest);

            await _repo.CadastrarBanco(request);
            return "Banco salvo com sucesso";
        }
    }
}
