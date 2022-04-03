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
    partial class ECommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                        .IsRequired()
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
                        .IsRequired()
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
                        .IsRequired()
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
                        .IsRequired()
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

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.RoleClaimEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RoleClaim", "identity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Role", "identity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserClaimEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserClaim", "identity");
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
                        .IsRequired()
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

                    b.Property<Guid?>("ShopEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ShopEntityId");

                    b.ToTable("User", "identity");
                });

            modelBuilder.Entity("JustCommerce.Domain.Entities.Identity.UserRoleEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRole", "identity");
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
                    b.HasOne("JustCommerce.Domain.Entities.Company.ShopEntity", null)
                        .WithMany("User")
                        .HasForeignKey("ShopEntityId");
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
#pragma warning restore 612, 618
        }
    }
}
