using GoodbyeUsp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp
{
    internal class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Error).EnableDetailedErrors().EnableSensitiveDataLogging();
        }

        public DbSet<Firme> Firmes { get; set; }
        public DbSet<EnergyAreal> EnergyAreals { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Disloc> Dislocs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Citizen> Citizens { get; set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().OwnsMany(cl => cl.GraphPays, fs =>
            {
                fs.ToTable("GraphPays");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                fs.HasKey(e => new { e.ClientId, e.DateBegin });
            });

            modelBuilder.Entity<Client>().OwnsMany(cl => cl.MonetizedDiscounts, fs =>
            {
                fs.ToTable("MonetizedDiscounts");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                fs.HasKey(e => new { e.ClientId, e.DateBank });
            });

            modelBuilder.Entity<Client>().OwnsMany(cl => cl.Pay64s, fs =>
            {
                fs.ToTable("Payments64");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                fs.HasKey(e => new { e.ClientId, e.DateBank });
            });

            modelBuilder.Entity<Client>().OwnsMany(cl => cl.Pay375s, fs =>
            {
                fs.ToTable("Payments375");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                fs.HasKey(e => new { e.ClientId, e.DateBank});
            });

			modelBuilder.Entity<Client>().OwnsMany(cl => cl.Payments, fs =>
            {
                fs.ToTable("Payments");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                //fs.HasKey(e => new { e.ClientId, e.DateBank });
            });

			modelBuilder.Entity<Client>().OwnsMany(cl => cl.Subsidies, fs =>
            {
                fs.ToTable("Subsidies");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                fs.HasKey(e => new { e.ClientId, e.DateBank });
            });

            modelBuilder.Entity<Client>().OwnsMany(cl => cl.Equipments, fs =>
            {
                fs.ToTable("Equipments");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                fs.HasKey(e => new { e.ClientId, e.Codeequip, e.DateBegin });
            });

            modelBuilder.Entity<Citizen>().OwnsMany(c => c.Docs, d =>
            {
                d.ToTable("CitizenDocs");
                d.WithOwner().HasForeignKey(o => o.Citizenid);
            });

            modelBuilder.Entity<Client>().OwnsMany(cl => cl.MonthConsums, fs =>
            {
                fs.ToTable("MonthConsumes");
                fs.WithOwner().HasForeignKey(f => f.ClientId);
                fs.HasKey(e => new { e.ClientId, e.Month });
            });

            modelBuilder.Entity<Client>().OwnsMany(cl => cl.TypeTarifs, fs =>
              {
                  fs.ToTable("TypeTarifs");
                  fs.WithOwner().HasForeignKey(f => f.ClientId);
                  fs.HasKey(e => new { e.ClientId, e.DateBegin });
              });

            modelBuilder.Entity<Client>().OwnsOne(cl => cl.FactStart, fs =>
            {
                fs.ToTable("FactStarts");
                fs.WithOwner().HasForeignKey(f => f.Clientid);
            });

            modelBuilder.Entity<Disloc>()
                .HasOne<EnergyAreal>()
                .WithMany()
                .HasForeignKey(e => e.Codeenergyareal);

            modelBuilder.Entity<Client>()
                .HasOne<Firme>()
                .WithMany()
                .HasForeignKey(e=>e.CodeOwner)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne<Firme>()
                .WithMany()
                .HasForeignKey(e => e.CodeExchange)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(e => e.House)
                .WithMany()
                .HasForeignKey(e => e.Codehouse);

            modelBuilder.Entity<Client>()
               .HasOne(e => e.House)
               .WithMany()
               .HasForeignKey(e => e.Codehouse);

            modelBuilder.Entity<EnergyAreal>().HasData(new[]
            {
                new EnergyAreal { Name = "Андрушівський РЕМ", CodeEnergyAreal = 1 },
                new EnergyAreal { Name = "Баранівський РЕМ", CodeEnergyAreal= 2 },
                new EnergyAreal { Name = "Бердичівський РЕМ", CodeEnergyAreal = 3 },
                new EnergyAreal { Name = "Брусилівський РЕМ", CodeEnergyAreal = 4 },
                new EnergyAreal { Name = "Ємільчинський РЕМ", CodeEnergyAreal = 6 },
                new EnergyAreal { Name = "Житомирський РЕМ", CodeEnergyAreal = 7 },
                new EnergyAreal { Name = "Зарічанський РЕМ", CodeEnergyAreal = 8 },
                new EnergyAreal { Name = "Коростенський РЕМ", CodeEnergyAreal = 9 },
                new EnergyAreal { Name = "Коростишівський РЕМ", CodeEnergyAreal = 11 },
                new EnergyAreal { Name = "Любарський РЕМ", CodeEnergyAreal = 13 },
                new EnergyAreal { Name = "Малинський РЕМ", CodeEnergyAreal = 14 },
                new EnergyAreal { Name = "Звягельський РЕМ", CodeEnergyAreal = 16 },
                new EnergyAreal { Name = "Овруцький РЕМ", CodeEnergyAreal = 17 },
                new EnergyAreal { Name = "Олевський РЕМ", CodeEnergyAreal = 18 },
                new EnergyAreal { Name = "Попільнянський РЕМ", CodeEnergyAreal = 19 },
                new EnergyAreal { Name = "Пулинський РЕМ", CodeEnergyAreal = 23 },
                new EnergyAreal { Name = "Радомишльський РЕМ", CodeEnergyAreal = 20 },
                new EnergyAreal { Name = "Романівський РЕМ", CodeEnergyAreal = 21 },
                new EnergyAreal { Name = "Хорошівський РЕМ", CodeEnergyAreal = 5 },
                new EnergyAreal { Name = "Черняхівський РЕМ", CodeEnergyAreal = 24 },
                new EnergyAreal { Name = "Чуднівський РЕМ", CodeEnergyAreal = 25 }
            });

            modelBuilder.Entity<Firme>().HasData(new[]
           {
                new Firme { NameFirme = "АТ \"Житомирробленерго\"", CodeFirme = 101, CodeGroup = 8 },
                new Firme { NameFirme = "АТ \"Укрзалізниця\"", CodeFirme = 102, CodeGroup = 8 },

               
                new Firme { NameFirme = "Андрушівський ЦОК", CodeFirme = 201, CodeGroup = 7 },
                new Firme { NameFirme = "Баранівський ЦОК", CodeFirme= 202, CodeGroup = 7 },
                new Firme { NameFirme = "Бердичівський ЦОК", CodeFirme = 203, CodeGroup = 7 },
                new Firme { NameFirme = "Брусилівський ЦОК", CodeFirme = 204, CodeGroup = 7 },
                new Firme { NameFirme = "Ємільчинський ЦОК", CodeFirme = 206, CodeGroup = 7 },
                new Firme { NameFirme = "Житомирський ЦОК", CodeFirme = 207, CodeGroup = 7 },
                new Firme { NameFirme = "Зарічанський ЦОК", CodeFirme = 208, CodeGroup = 7 },
                new Firme { NameFirme = "Коростенський ЦОК", CodeFirme = 209, CodeGroup = 7 },
                new Firme { NameFirme = "Коростишівський ЦОК", CodeFirme = 211, CodeGroup = 7 },
                new Firme { NameFirme = "Любарський ЦОК", CodeFirme = 213, CodeGroup = 7 },
                new Firme { NameFirme = "Малинський ЦОК", CodeFirme = 214, CodeGroup = 7 },
                new Firme { NameFirme = "Звягельський ЦОК", CodeFirme = 216, CodeGroup = 7 },
                new Firme { NameFirme = "Овруцький ЦОК", CodeFirme = 217, CodeGroup = 7 },
                new Firme { NameFirme = "Олевський ЦОК", CodeFirme = 218, CodeGroup = 7 },
                new Firme { NameFirme = "Попільнянський ЦОК", CodeFirme = 219, CodeGroup = 7 },
                new Firme { NameFirme = "Пулинський ЦОК", CodeFirme = 223, CodeGroup = 7 },
                new Firme { NameFirme = "Радомишльський ЦОК", CodeFirme = 220, CodeGroup = 7 },
                new Firme { NameFirme = "Романівський ЦОК", CodeFirme = 221, CodeGroup = 7 },
                new Firme { NameFirme = "Хорошівський ЦОК", CodeFirme = 205, CodeGroup = 7 },
                new Firme { NameFirme = "Черняхівський ЦОК", CodeFirme = 224, CodeGroup = 7 },
                new Firme { NameFirme = "Чуднівський ЦОК", CodeFirme = 225, CodeGroup = 7 }
            });
        }
    }
}
