﻿// <auto-generated />
using System;
using JustCommerce.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    [DbContext(typeof(JustCommerceDbContext))]
    partial class JustCommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JustCommerce.Domain.Entities.Company.StoreEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyVat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Hosts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SslEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("_Store");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.CMSUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("FtpPhotoFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Profile")
                        .HasColumnType("int");

                    b.Property<int>("RegisterSource")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SelectedShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Theme")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserPermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PermissionDomainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermissionFlagValue")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermissionEntity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserStoreEntity", b =>
                {
                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StoreId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserStoreEntity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Language.LanguageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DefaultLanguage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameInternational")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOrginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("LanguageEntity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.PredefinedProductAttributeValueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsPreSelected")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceAdjustment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("PriceAdjustmentUsePercentage")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductAttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("WeightAdjustment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("ProductAttributeId");

                    b.ToTable("PredefinedProductAttributeValueEntity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.PredefinedProductAttributeValueLangEntity", b =>
                {
                    b.Property<Guid>("PredefinedProductAttributeValueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PredefinedProductAttributeValueId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PredefinedProductAttributeValueLangEntity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.ProductAttributeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("_ProductAttribute");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.ProductAttributeLangEntity", b =>
                {
                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductAttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId", "ProductAttributeId");

                    b.HasIndex("ProductAttributeId");

                    b.ToTable("ProductAttributeLangEntity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserPermissionEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Identity.CMSUserEntity", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserStoreEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Company.StoreEntity", "Store")
                        .WithMany("AllowedUser")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JustCommerce.Domain.Entities.Identity.CMSUserEntity", "User")
                        .WithMany("AllowedStore")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Language.LanguageEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Company.StoreEntity", "Store")
                        .WithMany("Language")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.PredefinedProductAttributeValueEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Products.Attributes.ProductAttributeEntity", "ProductAttribute")
                        .WithMany("PredefinedProductAttributeValue")
                        .HasForeignKey("ProductAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductAttribute");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.PredefinedProductAttributeValueLangEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Language.LanguageEntity", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JustCommerce.Domain.Entities.Products.Attributes.PredefinedProductAttributeValueEntity", "PredefinedProductAttributeValue")
                        .WithMany("PredefinedProductAttributeValueLang")
                        .HasForeignKey("PredefinedProductAttributeValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("PredefinedProductAttributeValue");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.ProductAttributeEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Company.StoreEntity", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.ProductAttributeLangEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Language.LanguageEntity", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JustCommerce.Domain.Entities.Products.Attributes.ProductAttributeEntity", "ProductAttribute")
                        .WithMany("ProductAttributeLang")
                        .HasForeignKey("ProductAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("ProductAttribute");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Company.StoreEntity", b =>
                {
                    b.Navigation("AllowedUser");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.CMSUserEntity", b =>
                {
                    b.Navigation("AllowedStore");

                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.PredefinedProductAttributeValueEntity", b =>
                {
                    b.Navigation("PredefinedProductAttributeValueLang");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Products.Attributes.ProductAttributeEntity", b =>
                {
                    b.Navigation("PredefinedProductAttributeValue");

                    b.Navigation("ProductAttributeLang");
                });
#pragma warning restore 612, 618
        }
    }
}
