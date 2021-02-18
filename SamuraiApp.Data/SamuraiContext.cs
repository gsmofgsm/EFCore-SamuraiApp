using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=SamuraiTestData");
                //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Transaction.Name }, LogLevel.Debug)
                //.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>()
                .HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>
                (bs => bs.HasOne<Battle>().WithMany(),
                 bs => bs.HasOne<Samurai>().WithMany())
                .Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getdate()");

            // Because we don't have DbSet for Horse
            // DB can't use DbSet name for db table
            // it uses class name instead for db table
            // which is sigular, here we change it to plural
            modelBuilder.Entity<Horse>().ToTable("Horses");
            // The table Will get renamed, so no dat loss

            modelBuilder.Entity<SamuraiBattleStat>()
                .HasNoKey()  // so EF core won't complain about there is no key, and EF core won't bother tracking any more
                .ToView("SamuraiBattleStats");  // so EF core knows there is a view alreay, and won't create a new table
        }
    }
}
