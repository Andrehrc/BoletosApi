using BoletosApi.Context;
using BoletosApi.Models.Models;
using BoletosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoletosApi.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly ApplicationDbContext _context;

        public BancoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Banco>> ObterBancos()
        {
            return await _context.Bancos.ToListAsync();
        }

        public async Task<Banco> ObterBancoPorCodigo(string codigo)
        {
            return await _context.Bancos.FirstOrDefaultAsync(w => w.Codigo == codigo);
        }

        public async Task CadastrarBanco(Banco bancoObj)
        {
            await _context.Bancos.AddAsync(bancoObj);
            await _context.SaveChangesAsync();
        }
    }
}
