using EnergyKids.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyKids.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<DicaEconomia> DicasEconomias { get; set; }
    }
}
