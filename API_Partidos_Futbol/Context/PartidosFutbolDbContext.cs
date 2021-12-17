using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Utilities.Models;

#nullable disable

namespace API_Partidos_Futbol.Context
{
    public partial class PartidosFutbolDbContext : DbContext
    {
        public PartidosFutbolDbContext()
        {
        }

        public PartidosFutbolDbContext(DbContextOptions<PartidosFutbolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PartidoDisputado> PartidosDisputados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=futbolBBDD");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PartidoDisputado>(entity =>
            {
                entity.ToTable("PartidoDisputado");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Division).HasColumnName("division");

                entity.Property(e => e.LocalGoals).HasColumnName("localGoals");

                entity.Property(e => e.LocalTeam)
                    .HasMaxLength(50)
                    .HasColumnName("localTeam");

                entity.Property(e => e.Round).HasColumnName("round");

                entity.Property(e => e.Season)
                    .HasMaxLength(50)
                    .HasColumnName("season");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.VisitorGoals).HasColumnName("visitorGoals");

                entity.Property(e => e.VisitorTeam)
                    .HasMaxLength(50)
                    .HasColumnName("visitorTeam");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
