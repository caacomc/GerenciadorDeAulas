using ApiGerenciadorAulas.Data;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escola_Models;
using ApiGerenciadorAulas.Services;


namespace ApiGerenciadorAulas.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class VerificarUsuarioSenha : ControllerBase
    {
       private readonly LoginServiceAPI _loginService;

        public VerificarUsuarioSenha(LoginServiceAPI loginService)
        { 
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetUsuarioSenha([FromBody] Login login)
        {
            var usuario = await _loginService.ValidarUsuario(login.NomeUsuario, login.Senha);

            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
    }
}
