﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamplePermissions;

#nullable disable

namespace SamplePermissions.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220503184838_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("identity")
                .HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityPermission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("PermissionNameIndex");

                    b.ToTable("Permissions", "identity");

                    b.HasData(
                        new
                        {
                            Id = "5b9c4926-3dc6-447c-a092-addab890a15f",
                            ConcurrencyStamp = "3668bfdc-0a1f-4cad-b16a-aecb089c36f1",
                            Name = "Invoice.Read",
                            NormalizedName = "INVOICE.READ"
                        },
                        new
                        {
                            Id = "be5b92e5-c6c6-480b-b235-d4df402a73cc",
                            ConcurrencyStamp = "52b464fa-3daf-4ad7-9979-8a3690a2c805",
                            Name = "Invoice.Write",
                            NormalizedName = "INVOICE.WRITE"
                        },
                        new
                        {
                            Id = "e123b8c0-0646-4075-b73e-07ca9d611c8e",
                            ConcurrencyStamp = "196a6681-647d-4485-8099-7cdb87ab0a43",
                            Name = "Invoice.Delete",
                            NormalizedName = "INVOICE.DELETE"
                        },
                        new
                        {
                            Id = "9dcb49c9-e732-4fb9-80a1-2c5efda61ab2",
                            ConcurrencyStamp = "f1f0cd5b-52d3-4aa0-abfc-ced5ff761f1d",
                            Name = "Invoice.Send",
                            NormalizedName = "INVOICE.SEND"
                        },
                        new
                        {
                            Id = "ef54d62d-a36b-4ab3-b868-f170c0054fac",
                            ConcurrencyStamp = "68b68788-ee56-4f0a-a65c-06be211d87f0",
                            Name = "Invoice.Payment",
                            NormalizedName = "INVOICE.PAYMENT"
                        });
                });

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityRolePermission<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PermissionId")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions", "identity");

                    b.HasData(
                        new
                        {
                            RoleId = "b0df7eae-a4f9-4d58-8795-ead2aaf6a483",
                            PermissionId = "5b9c4926-3dc6-447c-a092-addab890a15f"
                        },
                        new
                        {
                            RoleId = "2c77ea15-1559-4b9b-bc20-1d64892e4297",
                            PermissionId = "5b9c4926-3dc6-447c-a092-addab890a15f"
                        },
                        new
                        {
                            RoleId = "2c77ea15-1559-4b9b-bc20-1d64892e4297",
                            PermissionId = "e123b8c0-0646-4075-b73e-07ca9d611c8e"
                        },
                        new
                        {
                            RoleId = "c7ebaa11-c7ed-4357-b287-e0f2dd1eb3f2",
                            PermissionId = "5b9c4926-3dc6-447c-a092-addab890a15f"
                        },
                        new
                        {
                            RoleId = "c7ebaa11-c7ed-4357-b287-e0f2dd1eb3f2",
                            PermissionId = "be5b92e5-c6c6-480b-b235-d4df402a73cc"
                        },
                        new
                        {
                            RoleId = "c7ebaa11-c7ed-4357-b287-e0f2dd1eb3f2",
                            PermissionId = "9dcb49c9-e732-4fb9-80a1-2c5efda61ab2"
                        },
                        new
                        {
                            RoleId = "c7ebaa11-c7ed-4357-b287-e0f2dd1eb3f2",
                            PermissionId = "ef54d62d-a36b-4ab3-b868-f170c0054fac"
                        });
                });

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityTenant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DatabaseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasSeparateDatabase")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHierarchical")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("TenantNameIndex");

                    b.ToTable("AspNetTenants", "identity");
                });

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityTenant<string>", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("DatabaseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasSeparateDatabase")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHierarchical")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tenants", "identity");
                });

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityTenantRole<string>", b =>
                {
                    b.Property<string>("TenantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("TenantId", "RoleId");

                    b.ToTable("TenantRoles", "identity");
                });

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityTenantUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("TenantId");

                    b.ToTable("Users", "identity");

                    b.HasData(
                        new
                        {
                            Id = "a0f112af-5e39-4b3f-bc50-015591861ec0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "604adb8f-3fe0-4886-8ab1-04fc0a801e24",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "BOSS@COMPANY",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5tM19BCnMGTsQz8r8yFNvc4q9iWwkmCYHCsQYQUjlJ3XbZr1fx3tEC1QNNFxiuKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f285886d-79b2-484c-8bfe-ac078aeb0f1a",
                            TwoFactorEnabled = false,
                            UserName = "boss@company"
                        },
                        new
                        {
                            Id = "90a4dd66-78d1-4fff-a507-7f88735f7ab6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aacb25a1-2c23-4084-96fb-47b3cc5de90c",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "MANAGER@COMPANY",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5tM19BCnMGTsQz8r8yFNvc4q9iWwkmCYHCsQYQUjlJ3XbZr1fx3tEC1QNNFxiuKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f0163853-e1e8-4b56-a340-b75860c32f44",
                            TwoFactorEnabled = false,
                            UserName = "manager@company"
                        },
                        new
                        {
                            Id = "04517a45-d6f5-4993-888b-04c924902b3a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "037b1211-52ec-436b-9d94-61220e668846",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "EMPLOYEE@COMPANY",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5tM19BCnMGTsQz8r8yFNvc4q9iWwkmCYHCsQYQUjlJ3XbZr1fx3tEC1QNNFxiuKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7abe45b2-7087-4c1e-b558-176316ffce6a",
                            TwoFactorEnabled = false,
                            UserName = "employee@company"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", "identity");

                    b.HasData(
                        new
                        {
                            Id = "b0df7eae-a4f9-4d58-8795-ead2aaf6a483",
                            ConcurrencyStamp = "4c63b8f8-2f59-4d59-b813-d979ef5d9dfb",
                            Name = "Boss",
                            NormalizedName = "BOSS"
                        },
                        new
                        {
                            Id = "2c77ea15-1559-4b9b-bc20-1d64892e4297",
                            ConcurrencyStamp = "33717518-bfce-4361-8394-9c0e91d8e3ac",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "c7ebaa11-c7ed-4357-b287-e0f2dd1eb3f2",
                            ConcurrencyStamp = "3f6f57fc-45f6-4b7a-96e9-8a8b0162e044",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "identity");

                    b.HasData(
                        new
                        {
                            UserId = "a0f112af-5e39-4b3f-bc50-015591861ec0",
                            RoleId = "b0df7eae-a4f9-4d58-8795-ead2aaf6a483"
                        },
                        new
                        {
                            UserId = "90a4dd66-78d1-4fff-a507-7f88735f7ab6",
                            RoleId = "2c77ea15-1559-4b9b-bc20-1d64892e4297"
                        },
                        new
                        {
                            UserId = "04517a45-d6f5-4993-888b-04c924902b3a",
                            RoleId = "c7ebaa11-c7ed-4357-b287-e0f2dd1eb3f2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "identity");
                });

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityRolePermission<string>", b =>
                {
                    b.HasOne("AspNetCore.Authorization.Permissions.Identity.IdentityPermission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCore.Authorization.Permissions.Identity.IdentityTenantUser", b =>
                {
                    b.HasOne("AspNetCore.Authorization.Permissions.Identity.IdentityTenant", null)
                        .WithMany()
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AspNetCore.Authorization.Permissions.Identity.IdentityTenantUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AspNetCore.Authorization.Permissions.Identity.IdentityTenantUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore.Authorization.Permissions.Identity.IdentityTenantUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AspNetCore.Authorization.Permissions.Identity.IdentityTenantUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}