﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp;

namespace WebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApp.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_id")
                        .UseIdentityAlwaysColumn();

                    b.Property<int>("ProductCreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("product_created_by");

                    b.Property<DateTime>("ProductCreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("product_creation_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                    b.Property<string>("ProductDecimalNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("product_decimal_number");

                    b.Property<bool>("ProductDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("product_deleted");

                    b.Property<int?>("ProductDeletedBy")
                        .HasColumnType("integer")
                        .HasColumnName("product_deleted_by");

                    b.Property<DateTime?>("ProductDeletionDate")
                        .HasColumnType("date")
                        .HasColumnName("product_deletion_date");

                    b.HasKey("ProductId");

                    b.HasIndex(new[] { "ProductCreatedBy" }, "IX_product_creator");

                    b.HasIndex(new[] { "ProductDeletedBy" }, "IX_product_deleter");

                    b.HasIndex(new[] { "ProductDecimalNumber" }, "product_decimal_number")
                        .IsUnique();

                    b.HasIndex(new[] { "ProductId" }, "product_id")
                        .IsUnique();

                    b.ToTable("products");
                });

            modelBuilder.Entity("WebApp.Models.ProductComposition", b =>
                {
                    b.Property<int>("PurchasedProductId")
                        .HasColumnType("integer")
                        .HasColumnName("purchased_product_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int>("PurchasedProductAmount")
                        .HasColumnType("integer")
                        .HasColumnName("purchased_product_amount");

                    b.HasKey("PurchasedProductId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("product_composition");
                });

            modelBuilder.Entity("WebApp.Models.ProductTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.HasKey("TagId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("product_tags");
                });

            modelBuilder.Entity("WebApp.Models.PurchasedProduct", b =>
                {
                    b.Property<int>("PurchasedProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("purchased_product_id")
                        .UseIdentityAlwaysColumn();

                    b.Property<int>("PurchasedProductCreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("purchased_product_created_by");

                    b.Property<DateTime>("PurchasedProductCreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("purchased_product_creation_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                    b.Property<bool>("PurchasedProductDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("purchased_product_deleted");

                    b.Property<int?>("PurchasedProductDeletedBy")
                        .HasColumnType("integer")
                        .HasColumnName("purchased_product_deleted_by");

                    b.Property<DateTime?>("PurchasedProductDeletionDate")
                        .HasColumnType("date")
                        .HasColumnName("purchased_product_deletion_date");

                    b.Property<string>("PurchasedProductDocLink")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("purchased_product_doc_link");

                    b.Property<string>("PurchasedProductFullDescription")
                        .HasColumnType("text")
                        .HasColumnName("purchased_product_full_description");

                    b.Property<string>("PurchasedProductShortDescription")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("purchased_product_short_description");

                    b.Property<string>("PurchasedProductVendor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("purchased_product_vendor");

                    b.Property<string>("PurchasedProductVendorCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("purchased_product_vendor_code");

                    b.HasKey("PurchasedProductId");

                    b.HasIndex(new[] { "PurchasedProductCreatedBy" }, "IX_purchased_product_creator");

                    b.HasIndex(new[] { "PurchasedProductDeletedBy" }, "IX_purchased_product_deleter");

                    b.HasIndex(new[] { "PurchasedProductId" }, "purchased_product_id")
                        .IsUnique();

                    b.ToTable("purchased_products");
                });

            modelBuilder.Entity("WebApp.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("request_id")
                        .UseIdentityAlwaysColumn();

                    b.Property<int?>("RequestCreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("request_created_by");

                    b.Property<DateTime>("RequestCreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("request_creation_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                    b.Property<string>("RequestDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("request_description");

                    b.Property<string>("RequestName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("request_name");

                    b.HasKey("RequestId");

                    b.HasIndex(new[] { "RequestCreatedBy" }, "IX_request_author");

                    b.HasIndex(new[] { "RequestId" }, "request_id")
                        .IsUnique();

                    b.HasIndex(new[] { "RequestName" }, "request_name")
                        .IsUnique();

                    b.ToTable("requests");
                });

            modelBuilder.Entity("WebApp.Models.RequestComposition", b =>
                {
                    b.Property<int>("PurchasedProductId")
                        .HasColumnType("integer")
                        .HasColumnName("purchased_product_id");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer")
                        .HasColumnName("request_id");

                    b.Property<int>("PurchasedProductAmount")
                        .HasColumnType("integer")
                        .HasColumnName("purchased_product_amount");

                    b.HasKey("PurchasedProductId", "RequestId");

                    b.HasIndex("RequestId");

                    b.ToTable("request_composition");
                });

            modelBuilder.Entity("WebApp.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("tag_id")
                        .UseIdentityAlwaysColumn();

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("tag_name");

                    b.HasKey("TagId");

                    b.HasIndex(new[] { "TagId" }, "tag_id")
                        .IsUnique();

                    b.HasIndex(new[] { "TagName" }, "tag_name")
                        .IsUnique();

                    b.ToTable("tags");
                });

            modelBuilder.Entity("WebApp.Models.Theme", b =>
                {
                    b.Property<int>("ThemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("theme_id")
                        .UseIdentityAlwaysColumn();

                    b.Property<int>("ThemeCreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("theme_created_by");

                    b.Property<DateTime>("ThemeCreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("theme_creation_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(2)");

                    b.Property<bool>("ThemeDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("theme_deleted");

                    b.Property<int?>("ThemeDeletedBy")
                        .HasColumnType("integer")
                        .HasColumnName("theme_deleted_by");

                    b.Property<DateTime?>("ThemeDeletionDate")
                        .HasColumnType("date")
                        .HasColumnName("theme_deletion_date");

                    b.Property<string>("ThemeDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("theme_description");

                    b.Property<string>("ThemeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("theme_name");

                    b.HasKey("ThemeId");

                    b.HasIndex(new[] { "ThemeCreatedBy" }, "IX_Relationship1");

                    b.HasIndex(new[] { "ThemeDeletedBy" }, "IX_Relationship2");

                    b.HasIndex(new[] { "ThemeId" }, "theme_id")
                        .IsUnique();

                    b.HasIndex(new[] { "ThemeName" }, "theme_name")
                        .IsUnique();

                    b.ToTable("themes");
                });

            modelBuilder.Entity("WebApp.Models.ThemeComposition", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int>("ThemeId")
                        .HasColumnType("integer")
                        .HasColumnName("theme_id");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("integer")
                        .HasColumnName("product_amount");

                    b.HasKey("ProductId", "ThemeId");

                    b.HasIndex("ThemeId");

                    b.ToTable("theme_composition");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .UseIdentityAlwaysColumn();

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("user_login");

                    b.Property<string>("UserPasswordHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("user_password_hash");

                    b.Property<int>("UserPasswordSalt")
                        .HasColumnType("integer")
                        .HasColumnName("user_password_salt");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "UserId" }, "user_id")
                        .IsUnique();

                    b.HasIndex(new[] { "UserLogin" }, "user_login")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebApp.Models.Product", b =>
                {
                    b.HasOne("WebApp.Models.User", "ProductCreatedByNavigation")
                        .WithMany("ProductProductCreatedByNavigations")
                        .HasForeignKey("ProductCreatedBy")
                        .HasConstraintName("product_creator")
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", "ProductDeletedByNavigation")
                        .WithMany("ProductProductDeletedByNavigations")
                        .HasForeignKey("ProductDeletedBy")
                        .HasConstraintName("product_deleter");

                    b.Navigation("ProductCreatedByNavigation");

                    b.Navigation("ProductDeletedByNavigation");
                });

            modelBuilder.Entity("WebApp.Models.ProductComposition", b =>
                {
                    b.HasOne("WebApp.Models.Product", "Product")
                        .WithMany("ProductCompositions")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_consist_of_purchased_products")
                        .IsRequired();

                    b.HasOne("WebApp.Models.PurchasedProduct", "PurchasedProduct")
                        .WithMany("ProductCompositions")
                        .HasForeignKey("PurchasedProductId")
                        .HasConstraintName("purchased_products_included_in_products")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("PurchasedProduct");
                });

            modelBuilder.Entity("WebApp.Models.ProductTag", b =>
                {
                    b.HasOne("WebApp.Models.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_has_tags")
                        .IsRequired();

                    b.HasOne("WebApp.Models.Tag", "Tag")
                        .WithMany("ProductTags")
                        .HasForeignKey("TagId")
                        .HasConstraintName("tag_refers_to_products")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("WebApp.Models.PurchasedProduct", b =>
                {
                    b.HasOne("WebApp.Models.User", "PurchasedProductCreatedByNavigation")
                        .WithMany("PurchasedProductPurchasedProductCreatedByNavigations")
                        .HasForeignKey("PurchasedProductCreatedBy")
                        .HasConstraintName("purchased_product_creator")
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", "PurchasedProductDeletedByNavigation")
                        .WithMany("PurchasedProductPurchasedProductDeletedByNavigations")
                        .HasForeignKey("PurchasedProductDeletedBy")
                        .HasConstraintName("purchased_product_deleter");

                    b.Navigation("PurchasedProductCreatedByNavigation");

                    b.Navigation("PurchasedProductDeletedByNavigation");
                });

            modelBuilder.Entity("WebApp.Models.Request", b =>
                {
                    b.HasOne("WebApp.Models.User", "RequestCreatedByNavigation")
                        .WithMany("Requests")
                        .HasForeignKey("RequestCreatedBy")
                        .HasConstraintName("request_author");

                    b.Navigation("RequestCreatedByNavigation");
                });

            modelBuilder.Entity("WebApp.Models.RequestComposition", b =>
                {
                    b.HasOne("WebApp.Models.PurchasedProduct", "PurchasedProduct")
                        .WithMany("RequestCompositions")
                        .HasForeignKey("PurchasedProductId")
                        .HasConstraintName("purchased_products_included_in_request")
                        .IsRequired();

                    b.HasOne("WebApp.Models.Request", "Request")
                        .WithMany("RequestCompositions")
                        .HasForeignKey("RequestId")
                        .HasConstraintName("request_consist_of_purchased_products")
                        .IsRequired();

                    b.Navigation("PurchasedProduct");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("WebApp.Models.Theme", b =>
                {
                    b.HasOne("WebApp.Models.User", "ThemeCreatedByNavigation")
                        .WithMany("ThemeThemeCreatedByNavigations")
                        .HasForeignKey("ThemeCreatedBy")
                        .HasConstraintName("theme_creator")
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", "ThemeDeletedByNavigation")
                        .WithMany("ThemeThemeDeletedByNavigations")
                        .HasForeignKey("ThemeDeletedBy")
                        .HasConstraintName("theme_deleter");

                    b.Navigation("ThemeCreatedByNavigation");

                    b.Navigation("ThemeDeletedByNavigation");
                });

            modelBuilder.Entity("WebApp.Models.ThemeComposition", b =>
                {
                    b.HasOne("WebApp.Models.Product", "Product")
                        .WithMany("ThemeCompositions")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_included_in_themes")
                        .IsRequired();

                    b.HasOne("WebApp.Models.Theme", "Theme")
                        .WithMany("ThemeCompositions")
                        .HasForeignKey("ThemeId")
                        .HasConstraintName("theme_consist_of_products")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("WebApp.Models.Product", b =>
                {
                    b.Navigation("ProductCompositions");

                    b.Navigation("ProductTags");

                    b.Navigation("ThemeCompositions");
                });

            modelBuilder.Entity("WebApp.Models.PurchasedProduct", b =>
                {
                    b.Navigation("ProductCompositions");

                    b.Navigation("RequestCompositions");
                });

            modelBuilder.Entity("WebApp.Models.Request", b =>
                {
                    b.Navigation("RequestCompositions");
                });

            modelBuilder.Entity("WebApp.Models.Tag", b =>
                {
                    b.Navigation("ProductTags");
                });

            modelBuilder.Entity("WebApp.Models.Theme", b =>
                {
                    b.Navigation("ThemeCompositions");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Navigation("ProductProductCreatedByNavigations");

                    b.Navigation("ProductProductDeletedByNavigations");

                    b.Navigation("PurchasedProductPurchasedProductCreatedByNavigations");

                    b.Navigation("PurchasedProductPurchasedProductDeletedByNavigations");

                    b.Navigation("Requests");

                    b.Navigation("ThemeThemeCreatedByNavigations");

                    b.Navigation("ThemeThemeDeletedByNavigations");
                });
#pragma warning restore 612, 618
        }
    }
}
