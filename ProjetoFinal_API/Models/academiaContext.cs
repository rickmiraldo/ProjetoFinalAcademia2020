using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoFinal_API.Models
{
    public partial class academiaContext : DbContext
    {
        public academiaContext()
        {
        }

        public academiaContext(DbContextOptions<academiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleProduct> SaleProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=academiaffaltran.database.windows.net;Database=academia;User Id=academiaffaltranuser;Password=Pass@word;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NameClient)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistDate).HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.SaleDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Sale__ClientID__656C112C");
            });

            modelBuilder.Entity<SaleProduct>(entity =>
            {
                entity.HasKey(e => new { e.SaleId, e.ProductId });

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaleProdu__Produ__6C190EBB");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleProduct)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaleProdu__SaleI__6B24EA82");
            });
        }
    }
}
