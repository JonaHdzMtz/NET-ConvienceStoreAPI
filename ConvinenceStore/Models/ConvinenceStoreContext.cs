using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConvinenceStore.Models;

public partial class ConvinenceStoreContext : DbContext
{
    public ConvinenceStoreContext()
    {
    }

    public ConvinenceStoreContext(DbContextOptions<ConvinenceStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSale> ProductSales { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JONA-WINDOWS\\SQLExpress;Database=ConvinenceStore;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("Product");
        });

        modelBuilder.Entity<ProductSale>(entity =>
        {
            entity.HasKey(e => e.IdProductSale);

            entity.ToTable("ProductSale");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_ProductSale_Product");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("FK_ProductSale_Sale");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale);

            entity.ToTable("Sale");

            entity.Property(e => e.SaleDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Sale_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_User_1");

            entity.ToTable("User");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
