using ApiGerenciadorAulas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escola_Models;

namespace ApiGerenciadorAulas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TesteController(AppDbContext context)
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDados()
        {
            try
            {
                var dados = await _context.Usuarios.ToListAsync();
                return Ok(dados);
            }
            catch (Exception ex) { return BadRequest($"Erro de conexão: " + ex.Message); }
        }
    }
}
