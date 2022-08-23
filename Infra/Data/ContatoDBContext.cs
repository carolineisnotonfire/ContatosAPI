using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class ContatoDBContext : DbContext
    {
        public ContatoDBContext(DbContextOptions<ContatoDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}