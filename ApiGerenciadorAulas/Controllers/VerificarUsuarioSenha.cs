using ApiGerenciadorAulas.Data;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escola_Models;


namespace ApiGerenciadorAulas.Controllers
{
    [Route("api/verificar")]
    [ApiController]
    public class VerificarUsuarioSenha : ControllerBase
    {
        private readonly AppDbContext _context;

        public VerificarUsuarioSenha(AppDbContext context) 
        { 
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetUsuarioSenha([FromBody] Login login)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome_Usuario == login.NomeUsuario && u.SenhaUsuario == login.Senha);

            if (usuario == null) 
            {
                return NotFound(new { mensagem = "Usuario não encontrado" });
            }


            return Ok(usuario);

            
        }
    }
}
