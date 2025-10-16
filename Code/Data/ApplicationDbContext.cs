using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexaWorksTickets.Code.Models.Entities;

namespace NexaWorksTickets.Code.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVersion> Versions { get; set; }
        public DbSet<Os> Os { get; set; }
        public DbSet<VersionOs> VersionOs { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductVersion>()
                .HasIndex(pv => new { pv.ProductId, pv.Number })
                .IsUnique();

            modelBuilder.Entity<VersionOs>()
                .HasIndex(vo => new { vo.VersionId, vo.OsId })
                .IsUnique();

            modelBuilder.Entity<ProductVersion>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.Versions)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VersionOs>()
                .HasOne(vo => vo.Version)
                .WithMany(pv => pv.VersionOs)
                .HasForeignKey(vo => vo.VersionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VersionOs>()
                .HasOne(vo => vo.Os)
                .WithMany(o => o.VersionOs)
                .HasForeignKey(vo => vo.OsId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(s => s.Status)
                .WithMany(t => t.Tickets)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.VersionOs)
                .WithMany(vo => vo.Tickets)
                .HasForeignKey(t => t.VersionOsId)
                .OnDelete(DeleteBehavior.Cascade);


            // Produits
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Trader en Herbe" },
                new Product { Id = 2, Name = "Maître des Investissements" },
                new Product { Id = 3, Name = "Planificateur d’Entraînement" },
                new Product { Id = 4, Name = "Planificateur d’Anxiété Sociale" }
            );

            // Versions
            modelBuilder.Entity<ProductVersion>().HasData(
                // Trader en Herbe
                new ProductVersion { Id = 1, ProductId = 1, Number = "1.0" },
                new ProductVersion { Id = 2, ProductId = 1, Number = "1.1" },
                new ProductVersion { Id = 3, ProductId = 1, Number = "1.2" },
                new ProductVersion { Id = 4, ProductId = 1, Number = "1.3" },

                // Maître des Investissements
                new ProductVersion { Id = 5, ProductId = 2, Number = "1.0" },
                new ProductVersion { Id = 6, ProductId = 2, Number = "2.0" },
                new ProductVersion { Id = 7, ProductId = 2, Number = "2.1" },

                // Planificateur d’Entraînement
                new ProductVersion { Id = 8, ProductId = 3, Number = "1.0" },
                new ProductVersion { Id = 9, ProductId = 3, Number = "1.1" },
                new ProductVersion { Id = 10, ProductId = 3, Number = "2.0" },

                // Planificateur d’Anxiété Sociale
                new ProductVersion { Id = 11, ProductId = 4, Number = "1.0" },
                new ProductVersion { Id = 12, ProductId = 4, Number = "1.1" }
            );

            // 3️ OS
            modelBuilder.Entity<Os>().HasData(
                new Os { Id = 1, Name = "Linux" },
                new Os { Id = 2, Name = "MacOS" },
                new Os { Id = 3, Name = "Windows" },
                new Os { Id = 4, Name = "Android" },
                new Os { Id = 5, Name = "iOS" },
                new Os { Id = 6, Name = "Windows Mobile" }

            );

            // 4️ VersionOs (uniquement couples existants dans le tableau)
            modelBuilder.Entity<VersionOs>().HasData(
                new VersionOs { Id = 1, VersionId = 1, OsId = 1 },
                new VersionOs { Id = 2, VersionId = 1, OsId = 3 },
                new VersionOs { Id = 3, VersionId = 2, OsId = 1 },
                new VersionOs { Id = 4, VersionId = 2, OsId = 2 },
                new VersionOs { Id = 5, VersionId = 2, OsId = 3 },
                new VersionOs { Id = 6, VersionId = 3, OsId = 1 },
                new VersionOs { Id = 7, VersionId = 3, OsId = 2 },
                new VersionOs { Id = 8, VersionId = 3, OsId = 3 },
                new VersionOs { Id = 9, VersionId = 3, OsId = 4 },
                new VersionOs { Id = 10, VersionId = 3, OsId = 5 },
                new VersionOs { Id = 11, VersionId = 3, OsId = 6 },
                new VersionOs { Id = 12, VersionId = 4, OsId = 2 },
                new VersionOs { Id = 13, VersionId = 4, OsId = 3 },
                new VersionOs { Id = 14, VersionId = 4, OsId = 4 },
                new VersionOs { Id = 15, VersionId = 4, OsId = 5 },
                new VersionOs { Id = 16, VersionId = 5, OsId = 2 },
                new VersionOs { Id = 17, VersionId = 5, OsId = 5 },
                new VersionOs { Id = 18, VersionId = 6, OsId = 2 },
                new VersionOs { Id = 19, VersionId = 6, OsId = 4 },
                new VersionOs { Id = 20, VersionId = 6, OsId = 5 },
                new VersionOs { Id = 21, VersionId = 7, OsId = 2 },
                new VersionOs { Id = 22, VersionId = 7, OsId = 3 },
                new VersionOs { Id = 23, VersionId = 7, OsId = 4 },
                new VersionOs { Id = 24, VersionId = 7, OsId = 5 },
                new VersionOs { Id = 25, VersionId = 8, OsId = 1 },
                new VersionOs { Id = 26, VersionId = 8, OsId = 2 },
                new VersionOs { Id = 27, VersionId = 9, OsId = 1 },
                new VersionOs { Id = 28, VersionId = 9, OsId = 2 },
                new VersionOs { Id = 29, VersionId = 9, OsId = 3 },
                new VersionOs { Id = 30, VersionId = 9, OsId = 4 },
                new VersionOs { Id = 31, VersionId = 9, OsId = 5 },
                new VersionOs { Id = 32, VersionId = 9, OsId = 6 },
                new VersionOs { Id = 33, VersionId = 10, OsId = 2 },
                new VersionOs { Id = 34, VersionId = 10, OsId = 3 },
                new VersionOs { Id = 35, VersionId = 10, OsId = 4 },
                new VersionOs { Id = 36, VersionId = 10, OsId = 5 },
                new VersionOs { Id = 37, VersionId = 11, OsId = 2 },
                new VersionOs { Id = 38, VersionId = 11, OsId = 3 },
                new VersionOs { Id = 39, VersionId = 11, OsId = 4 },
                new VersionOs { Id = 40, VersionId = 11, OsId = 5 },
                new VersionOs { Id = 41, VersionId = 12, OsId = 2 },
                new VersionOs { Id = 42, VersionId = 12, OsId = 3 },
                new VersionOs { Id = 43, VersionId = 12, OsId = 4 },
                new VersionOs { Id = 44, VersionId = 12, OsId = 5 }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Résolu" },
                new Status { Id = 2, Name = "En cours" }
            );


        }

    }
}


