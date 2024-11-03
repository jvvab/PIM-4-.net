using Microsoft.EntityFrameworkCore;

namespace PIM_4_SEMESTRE.MinhaAplicacao.Data // Atualize conforme seu namespace
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Exemplo de DbSet
    }
}