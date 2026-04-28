

using ApiGerenciadorAulas.Data;
using Escola_Models;

namespace ApiGerenciadorAulas.Services
{
    public class CadastroAula
    {
        private readonly AppDbContext _context;
        public CadastroAula(AppDbContext context) 
        {
            _context = context;
        }

        public async Task Cadastrar(Aula aula)
        {
            _context.Aula.Add(aula);
            await _context.SaveChangesAsync();
        }
    }
}
