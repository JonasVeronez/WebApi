using Microsoft.EntityFrameworkCore;
using Sistema_cvihm.Data.Map;
using Sistema_cvihm.Models;

namespace Sistema_cvihm.Data
{
    public class SistemasTarefasContext : DbContext
    {
        public SistemasTarefasContext(DbContextOptions<SistemasTarefasContext> options)
            : base(options)
        {
        }

        public DbSet<UsersModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}