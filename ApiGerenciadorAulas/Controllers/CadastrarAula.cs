using ApiGerenciadorAulas.Data;
using ApiGerenciadorAulas.Services;
using Escola_Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciadorAulas.Controllers
{
    [Route("api/cadastro")]
    [ApiController]
    public class CadastrarAula : ControllerBase
    {
        private readonly CadastroAula _cadastroAula;
        public CadastrarAula(CadastroAula cadastroAula)
        {
            _cadastroAula = cadastroAula;
        }

        [HttpPost("aula")]
        public async Task<IActionResult> PostAula([FromBody] Aula aula) 
        {
            if (aula == null) 
            {
                return BadRequest("Aula vazia");
            }
            try
            {
                await _cadastroAula.Cadastrar(aula);
                return Ok(new { mensagem = "Aula cadastrada!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
