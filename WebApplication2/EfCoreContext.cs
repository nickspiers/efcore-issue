using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {
        }
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Man> Mans { get; set; }
        public DbSet<Chu> Chus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foo>()
                .HasData(new Foo
                {
                    Id = 1,
                    Name = "My Foo"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}