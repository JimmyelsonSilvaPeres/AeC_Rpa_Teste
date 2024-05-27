using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context :  DbContext
    {
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<Professor> Professor { get; set; }

        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}
