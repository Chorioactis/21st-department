using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApp.Models;

#nullable disable

namespace WebApp
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductComposition> ProductCompositions { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<PurchasedProduct> PurchasedProducts { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestComposition> RequestCompositions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<ThemeComposition> ThemeCompositions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=app_db;Username=postgres;Password=59735651");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.ProductCreatedBy, "IX_product_creator");

                entity.HasIndex(e => e.ProductDeletedBy, "IX_product_deleter");

                entity.HasIndex(e => e.ProductDecimalNumber, "product_decimal_number")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId, "product_id")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ProductCreatedBy).HasColumnName("product_created_by");

                entity.Property(e => e.ProductCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("product_creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                entity.Property(e => e.ProductDecimalNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("product_decimal_number");

                entity.Property(e => e.ProductDeleted).HasColumnName("product_deleted");

                entity.Property(e => e.ProductDeletedBy).HasColumnName("product_deleted_by");

                entity.Property(e => e.ProductDeletionDate)
                    .HasColumnType("date")
                    .HasColumnName("product_deletion_date");

                entity.HasOne(d => d.ProductCreatedByNavigation)
                    .WithMany(p => p.ProductProductCreatedByNavigations)
                    .HasForeignKey(d => d.ProductCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_creator");

                entity.HasOne(d => d.ProductDeletedByNavigation)
                    .WithMany(p => p.ProductProductDeletedByNavigations)
                    .HasForeignKey(d => d.ProductDeletedBy)
                    .HasConstraintName("product_deleter");
            });

            modelBuilder.Entity<ProductComposition>(entity =>
            {
                entity.HasKey(e => new { e.PurchasedProductId, e.ProductId });

                entity.ToTable("product_composition");

                entity.Property(e => e.PurchasedProductId).HasColumnName("purchased_product_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PurchasedProductAmount).HasColumnName("purchased_product_amount");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCompositions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_consist_of_purchased_products");

                entity.HasOne(d => d.PurchasedProduct)
                    .WithMany(p => p.ProductCompositions)
                    .HasForeignKey(d => d.PurchasedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("purchased_products_included_in_products");
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.ProductId });

                entity.ToTable("product_tags");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_has_tags");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tag_refers_to_products");
            });

            modelBuilder.Entity<PurchasedProduct>(entity =>
            {
                entity.ToTable("purchased_products");

                entity.HasIndex(e => e.PurchasedProductCreatedBy, "IX_purchased_product_creator");

                entity.HasIndex(e => e.PurchasedProductDeletedBy, "IX_purchased_product_deleter");

                entity.HasIndex(e => e.PurchasedProductId, "purchased_product_id")
                    .IsUnique();

                entity.Property(e => e.PurchasedProductId)
                    .HasColumnName("purchased_product_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.PurchasedProductCreatedBy).HasColumnName("purchased_product_created_by");

                entity.Property(e => e.PurchasedProductCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("purchased_product_creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                entity.Property(e => e.PurchasedProductDeleted).HasColumnName("purchased_product_deleted");

                entity.Property(e => e.PurchasedProductDeletedBy).HasColumnName("purchased_product_deleted_by");

                entity.Property(e => e.PurchasedProductDeletionDate)
                    .HasColumnType("date")
                    .HasColumnName("purchased_product_deletion_date");

                entity.Property(e => e.PurchasedProductDocLink)
                    .HasMaxLength(50)
                    .HasColumnName("purchased_product_doc_link");

                entity.Property(e => e.PurchasedProductFullDescription).HasColumnName("purchased_product_full_description");

                entity.Property(e => e.PurchasedProductShortDescription)
                    .HasMaxLength(20)
                    .HasColumnName("purchased_product_short_description");

                entity.Property(e => e.PurchasedProductVendor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("purchased_product_vendor");

                entity.Property(e => e.PurchasedProductVendorCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("purchased_product_vendor_code");

                entity.HasOne(d => d.PurchasedProductCreatedByNavigation)
                    .WithMany(p => p.PurchasedProductPurchasedProductCreatedByNavigations)
                    .HasForeignKey(d => d.PurchasedProductCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("purchased_product_creator");

                entity.HasOne(d => d.PurchasedProductDeletedByNavigation)
                    .WithMany(p => p.PurchasedProductPurchasedProductDeletedByNavigations)
                    .HasForeignKey(d => d.PurchasedProductDeletedBy)
                    .HasConstraintName("purchased_product_deleter");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("requests");

                entity.HasIndex(e => e.RequestCreatedBy, "IX_request_author");

                entity.HasIndex(e => e.RequestId, "request_id")
                    .IsUnique();

                entity.HasIndex(e => e.RequestName, "request_name")
                    .IsUnique();

                entity.Property(e => e.RequestId)
                    .HasColumnName("request_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.RequestCreatedBy).HasColumnName("request_created_by");

                entity.Property(e => e.RequestCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("request_creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                entity.Property(e => e.RequestDescription)
                    .IsRequired()
                    .HasColumnName("request_description");

                entity.Property(e => e.RequestName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("request_name");

                entity.HasOne(d => d.RequestCreatedByNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestCreatedBy)
                    .HasConstraintName("request_author");
            });

            modelBuilder.Entity<RequestComposition>(entity =>
            {
                entity.HasKey(e => new { e.PurchasedProductId, e.RequestId });

                entity.ToTable("request_composition");

                entity.Property(e => e.PurchasedProductId).HasColumnName("purchased_product_id");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.PurchasedProductAmount).HasColumnName("purchased_product_amount");

                entity.HasOne(d => d.PurchasedProduct)
                    .WithMany(p => p.RequestCompositions)
                    .HasForeignKey(d => d.PurchasedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("purchased_products_included_in_request");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestCompositions)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_consist_of_purchased_products");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.HasIndex(e => e.TagId, "tag_id")
                    .IsUnique();

                entity.HasIndex(e => e.TagName, "tag_name")
                    .IsUnique();

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tag_name");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.ToTable("themes");

                entity.HasIndex(e => e.ThemeCreatedBy, "IX_Relationship1");

                entity.HasIndex(e => e.ThemeDeletedBy, "IX_Relationship2");

                entity.HasIndex(e => e.ThemeId, "theme_id")
                    .IsUnique();

                entity.HasIndex(e => e.ThemeName, "theme_name")
                    .IsUnique();

                entity.Property(e => e.ThemeId)
                    .HasColumnName("theme_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ThemeCreatedBy).HasColumnName("theme_created_by");

                entity.Property(e => e.ThemeCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("theme_creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                entity.Property(e => e.ThemeDeleted).HasColumnName("theme_deleted");

                entity.Property(e => e.ThemeDeletedBy).HasColumnName("theme_deleted_by");

                entity.Property(e => e.ThemeDeletionDate)
                    .HasColumnType("date")
                    .HasColumnName("theme_deletion_date");

                entity.Property(e => e.ThemeDescription)
                    .IsRequired()
                    .HasColumnName("theme_description");

                entity.Property(e => e.ThemeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("theme_name");

                entity.HasOne(d => d.ThemeCreatedByNavigation)
                    .WithMany(p => p.ThemeThemeCreatedByNavigations)
                    .HasForeignKey(d => d.ThemeCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("theme_creator");

                entity.HasOne(d => d.ThemeDeletedByNavigation)
                    .WithMany(p => p.ThemeThemeDeletedByNavigations)
                    .HasForeignKey(d => d.ThemeDeletedBy)
                    .HasConstraintName("theme_deleter");
            });

            modelBuilder.Entity<ThemeComposition>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ThemeId });

                entity.ToTable("theme_composition");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ThemeId).HasColumnName("theme_id");

                entity.Property(e => e.ProductAmount).HasColumnName("product_amount");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ThemeCompositions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_included_in_themes");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.ThemeCompositions)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("theme_consist_of_products");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserId, "user_id")
                    .IsUnique();

                entity.HasIndex(e => e.UserLogin, "user_login")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("user_login");

                entity.Property(e => e.UserPasswordHash)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_password_hash");

                entity.Property(e => e.UserPasswordSalt).HasColumnName("user_password_salt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
