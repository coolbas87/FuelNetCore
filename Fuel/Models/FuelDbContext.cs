using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel.Models
{
    public class FuelDbContext : DbContext
    {
        public FuelDbContext(DbContextOptions<FuelDbContext> options)
            : base(options)
        { }

        public DbSet<dcDocuments> dcDocuments { get; set; }
        public DbSet<mnEnergyObjects> mnEnergyObjects { get; set; }
        public DbSet<mnEnergyObjectFiles> mnEnergyObjectFiles { get; set; }
        public DbSet<mnEnergyObjectFuel> mnEnergyObjectFuel { get; set; }

        public DbSet<esfDailyFuel> esfDailyFuel { get; set; }
        public DbSet<esfDailyFuelItems> esfDailyFuelItems { get; set; }
        public DbSet<esfFuelTypes> esfFuelTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("dcID");
            modelBuilder.Entity<dcDocuments>()
                .Property(d => d.dcID)
                .HasDefaultValueSql($"NEXT VALUE FOR dcID");
            modelBuilder.Entity<dcDocuments>()
                .Property(d => d.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.HasSequence<int>("dfiID");
            modelBuilder.Entity<esfDailyFuelItems>()
                .Property(fi => fi.dfiID)
                .HasDefaultValueSql($"NEXT VALUE FOR dfiID");
            modelBuilder.Entity<esfDailyFuelItems>()
                .Property(fi => fi.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.HasSequence<int>("fuID");
            modelBuilder.Entity<esfFuelTypes>()
                .Property(ft => ft.fuID)
                .HasDefaultValueSql($"NEXT VALUE FOR fuID");
            modelBuilder.Entity<esfFuelTypes>()
                .Property(ft => ft.CreateAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<esfFuelTypes>()
                .Property(ft => ft.IsHasIncome)
                .HasDefaultValue(false);
            modelBuilder.Entity<esfFuelTypes>()
                .Property(ft => ft.IsHasOutcome)
                .HasDefaultValue(false);
            modelBuilder.Entity<esfFuelTypes>()
                .Property(ft => ft.IsHasRemasins)
                .HasDefaultValue(false);
            modelBuilder.Entity<esfFuelTypes>()
                .Property(ft => ft.IsActive)
                .HasDefaultValue(true);

            modelBuilder.HasSequence<int>("eoID");
            modelBuilder.Entity<mnEnergyObjects>()
                .Property(eo => eo.eoID)
                .HasDefaultValueSql($"NEXT VALUE FOR eoID");
            modelBuilder.Entity<mnEnergyObjects>()
                .Property(eo => eo.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.HasSequence<int>("eofID");
            modelBuilder.Entity<mnEnergyObjectFuel>()
                .Property(eof => eof.eofID)
                .HasDefaultValueSql($"NEXT VALUE FOR eofID");

            modelBuilder.HasSequence<int>("eoflID");
            modelBuilder.Entity<mnEnergyObjectFiles>()
                .Property(eofl => eofl.eoflID)
                .HasDefaultValueSql($"NEXT VALUE FOR eoflID");
            modelBuilder.Entity<mnEnergyObjectFiles>()
                .Property(eofl => eofl.IsDefault)
                .HasDefaultValue(false);
        }
    }
}
