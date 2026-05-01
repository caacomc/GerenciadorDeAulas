using ApiGerenciadorAulas.Data;
using Escola_Models;

namespace ApiGerenciadorAulas.Services
{
    public class CadastroUsuario
    {
        private readonly AppDbContext _context;
        public CadastroUsuario(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task CadastrarUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email))
                throw new Exception("Email é obrigatório.");

            if (_context.Usuarios.Any(u => u.Email == usuario.Email))
                throw new Exception("Email repetido.");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
