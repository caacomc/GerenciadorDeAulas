using Microsoft.EntityFrameworkCore;
using Escola_Models;

namespace ApiGerenciadorAulas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
