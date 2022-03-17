using Microsoft.EntityFrameworkCore;

namespace TareasApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Tareas> Tareas { get; set; }   

    }
}
