using Microsoft.EntityFrameworkCore;

namespace Kurs.Shared.Data.Context
{
    public class KursContext : DbContext
    {
        public KursContext()
        { }

        public KursContext(DbContextOptions<KursContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Exchanger> Exchangers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}