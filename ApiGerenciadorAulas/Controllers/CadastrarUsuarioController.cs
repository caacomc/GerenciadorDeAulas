using ApiGerenciadorAulas.Services;
using Escola_Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciadorAulas.Controllers
{
    [Route("api/usuarios")]
    public class CadastrarUsuarioController : ControllerBase
    {
        private readonly CadastroUsuario _cadastroUsuario;
        public CadastrarUsuarioController(CadastroUsuario cadastroUsuario)
        {
            _cadastroUsuario = cadastroUsuario;
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuario vazio");
            }
            try
            {
                await _cadastroUsuario.CadastrarUsuario(usuario);
                return Ok(new { mensagem = "Usuario cadastrado!" });
            }
            catch (Exception ex)
            { 
                return StatusCode(500, ex.Message);
            }
        }
    }
}
