using ApiGerenciadorAulas.Data;
using Escola_Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGerenciadorAulas.Services
{
    public class LoginServiceAPI
    {
        private readonly AppDbContext _context;
        public LoginServiceAPI(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Usuario?> ValidarUsuario(string nome, string senha)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome_Usuario == nome && u.SenhaUsuario == senha);
            
        }
    }
}
