using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebApplication2.Entities;

namespace WebApplication2
{
    public class Ef6Context : DbContext
    {
        public Ef6Context(string connString) : base(connString)
        {
        }
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Man> Mans { get; set; }
        public DbSet<Chu> Chus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Man>().ToTable("Mans");

            base.OnModelCreating(modelBuilder);
        }
    }
}