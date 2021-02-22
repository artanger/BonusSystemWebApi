using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BunusSystemWebApi.Models
{
    public partial class BonusCardDBContext : DbContext
    {
        public BonusCardDBContext()
        {
        }

        public BonusCardDBContext(DbContextOptions<BonusCardDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BonusCard> BonusCards { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-JC81B6E\\SQLEXPRESS;Database=BonusCardDB;Trusted_Connection=True;");

                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<BonusCard>(entity =>
            {
                entity.ToTable("BonusCard");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardNumber).HasMaxLength(6);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                    //.HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BonusCardId).HasColumnName("BonusCardID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.BonusCard)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.BonusCardId)
                    .HasConstraintName("FK_Client_BonusCard");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
