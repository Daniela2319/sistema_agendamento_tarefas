using Microsoft.EntityFrameworkCore;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Tarefa> tarefas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
