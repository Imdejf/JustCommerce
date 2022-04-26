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

            modelBuilder.Entity("JustCommerce.Domain.Entities.Category.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("varchar(1500)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderValue")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ShopId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Category.CategoryLangEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryLang", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Common.ProductCategoryEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory", "common");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Company.ShopEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Shop", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Email.EmailAccountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("IampLogin")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("IampPassword")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("IampProt")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("IampServer")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pop3Login")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pop3Password")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pop3Prot")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Pop3Server")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SmtpLogin")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SmtpPassword")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SmtpProt")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SmtpServer")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("EmailAccount", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Email.EmailTemplateEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Actvie")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("EmailAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("EmailType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EmailAccountId");

                    b.ToTable("EmailTemplate", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumberConfirmed")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RegisterSource")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("User", "identity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserPermissionEntity", b =>
                {
                    b.Property<string>("PermissionDomainName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("PermissionFlagValue")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PermissionDomainName", "PermissionFlagValue", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermission", "identity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Language.LanguageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("LanguageEntity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Product.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("AvailabilityType")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MiniaturePhoto")
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("Newsletter")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Slug")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("Top")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("ShopId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Product.ProductFileEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductColor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductId", "PhotoPath");

                    b.HasIndex("Id");

                    b.ToTable("ProductFile", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Product.ProductLangEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("ImageDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("IsoCode")
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("MetaTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductPropertyJson")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Synonyms")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductLang", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ProductType", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypePropertyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderValue")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductTypeProperty", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypePropertyLangEntity", b =>
                {
                    b.Property<Guid?>("ProductTypePropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DefualtValue")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.HasKey("ProductTypePropertyId", "Name", "Value");

                    b.ToTable("ProductTypePropertyLang", (string)null);
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Category.CategoryEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Category.CategoryEntity", "Parent")
                        .WithMany("ChildCategory")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("JustCommerce.Domain.Entities.Company.ShopEntity", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Category.CategoryLangEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Category.CategoryEntity", "Category")
                        .WithMany("CategoryLang")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Common.ProductCategoryEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Category.CategoryEntity", "Category")
                        .WithMany("ProductCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JustCommerce.Domain.Entities.Product.ProductEntity", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Email.EmailAccountEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Company.ShopEntity", "Shop")
                        .WithMany("EmailAccount")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Email.EmailTemplateEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Email.EmailAccountEntity", "EmailAccount")
                        .WithMany("EmailTemplate")
                        .HasForeignKey("EmailAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailAccount");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Company.ShopEntity", "Shop")
                        .WithMany("User")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserPermissionEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Identity.UserEntity", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Product.ProductEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.ProductType.ProductTypeEntity", "ProductType")
                        .WithMany("Product")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JustCommerce.Domain.Entities.Company.ShopEntity", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Product.ProductFileEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Product.ProductEntity", "Product")
                        .WithMany("ProductFile")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Product.ProductLangEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Product.ProductEntity", "Product")
                        .WithMany("ProductLang")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypeEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.Company.ShopEntity", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypePropertyEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.ProductType.ProductTypeEntity", "ProductType")
                        .WithMany("ProductTypeProperty")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypePropertyLangEntity", b =>
                {
                    b.HasOne("JustCommerce.Domain.Entities.ProductType.ProductTypePropertyEntity", "ProductTypeProperty")
                        .WithMany("ProductTypePropertyLang")
                        .HasForeignKey("ProductTypePropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductTypeProperty");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Category.CategoryEntity", b =>
                {
                    b.Navigation("CategoryLang");

                    b.Navigation("ChildCategory");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Company.ShopEntity", b =>
                {
                    b.Navigation("EmailAccount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Email.EmailAccountEntity", b =>
                {
                    b.Navigation("EmailTemplate");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserEntity", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Product.ProductEntity", b =>
                {
                    b.Navigation("ProductCategory");

                    b.Navigation("ProductFile");

                    b.Navigation("ProductLang");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypeEntity", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("ProductTypeProperty");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.ProductType.ProductTypePropertyEntity", b =>
                {
                    b.Navigation("ProductTypePropertyLang");
                });
#pragma warning restore 612, 618
        }
    }
}
