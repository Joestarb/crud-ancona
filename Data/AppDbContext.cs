using Microsoft.EntityFrameworkCore;
using CrudApi.Models;

namespace CrudApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Administrativo> Administrativos { get; set; }
    }
}
