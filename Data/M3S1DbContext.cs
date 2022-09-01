using Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Data
{
    public class M3S1DbContext : DbContext
    {
        public M3S1DbContext(DbContextOptions<M3S1DbContext> opts) : base(opts)
        {

        }

        public DbSet<BandaModel> Bandas { get; set; }
        public DbSet<EventoModel> Eventos { get; set; }
    }
}
