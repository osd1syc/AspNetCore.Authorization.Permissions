﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamplePermissions;

#nullable disable

namespace SamplePermissions.Migrations
{
    [DbContext(typeof(InvoicesContext))]
    partial class InvoicesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityPermission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("PermissionNameIndex");

                    b.ToTable("Permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5b9c4926-3dc6-447c-a092-addab890a15f",
                            ConcurrencyStamp = "99e234d4-20ee-4ce7-8350-819f7771d7f1",
                            Name = "Invoice.Read",
                            NormalizedName = "INVOICE.READ"
                        },
                        new
                        {
                            Id = "be5b92e5-c6c6-480b-b235-d4df402a73cc",
                            ConcurrencyStamp = "2bac281e-3e0d-4539-8253-43bd395085cf",
                            Name = "Invoice.Write",
                            NormalizedName = "INVOICE.WRITE"
                        },
                        new
                        {
                            Id = "e123b8c0-0646-4075-b73e-07ca9d611c8e",
                            ConcurrencyStamp = "211e68ff-daf7-40d5-b909-3f0a71527a9b",
                            Name = "Invoice.Delete",
                            NormalizedName = "INVOICE.DELETE"
                        },
                        new
                        {
                            Id = "9dcb49c9-e732-4fb9-80a1-2c5efda61ab2",
                            ConcurrencyStamp = "3e3d63c9-f89a-479a-a8a3-6c8c2e43bdf6",
                            Name = "Invoice.Send",
                            NormalizedName = "INVOICE.SEND"
                        },
                        new
                        {
                            Id = "ef54d62d-a36b-4ab3-b868-f170c0054fac",
                            ConcurrencyStamp = "70e4e678-9a9e-45cc-9333-3b1359cd37b2",
                            Name = "Invoice.Payment",
                            NormalizedName = "INVOICE.PAYMENT"
                        });
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityRoleClaim", b =>
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

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityRolePermission", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PermissionId")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions", (string)null);

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

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserClaim", b =>
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

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserLogin", b =>
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

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);

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

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserToken", b =>
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

                    b.ToTable("UserTokens", (string)null);
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

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b0df7eae-a4f9-4d58-8795-ead2aaf6a483",
                            Name = "Boss",
                            NormalizedName = "BOSS"
                        },
                        new
                        {
                            Id = "2c77ea15-1559-4b9b-bc20-1d64892e4297",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "c7ebaa11-c7ed-4357-b287-e0f2dd1eb3f2",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a0f112af-5e39-4b3f-bc50-015591861ec0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cd004c21-761b-44ce-ac72-2416c8cf2d6e",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "BOSS@COMPANY",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5tM19BCnMGTsQz8r8yFNvc4q9iWwkmCYHCsQYQUjlJ3XbZr1fx3tEC1QNNFxiuKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f5db5a17-f1ff-4afb-a062-72d037807012",
                            TwoFactorEnabled = false,
                            UserName = "boss@company"
                        },
                        new
                        {
                            Id = "90a4dd66-78d1-4fff-a507-7f88735f7ab6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ff72801a-0c91-484c-bad7-f28f91b4aa17",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "MANAGER@COMPANY",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5tM19BCnMGTsQz8r8yFNvc4q9iWwkmCYHCsQYQUjlJ3XbZr1fx3tEC1QNNFxiuKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f31f23e5-dc57-49a9-a3f7-a6802aa523ba",
                            TwoFactorEnabled = false,
                            UserName = "manager@company"
                        },
                        new
                        {
                            Id = "04517a45-d6f5-4993-888b-04c924902b3a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7f146e5-cda3-490c-a610-9b7adc132065",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "EMPLOYEE@COMPANY",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ5tM19BCnMGTsQz8r8yFNvc4q9iWwkmCYHCsQYQUjlJ3XbZr1fx3tEC1QNNFxiuKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2ccae432-65b6-40b6-a0e7-f925cf0f6c77",
                            TwoFactorEnabled = false,
                            UserName = "employee@company"
                        });
                });

            modelBuilder.Entity("SamplePermissions.Model.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Invoices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8faf03b7-0ed0-4db5-9276-6574ea519e04"),
                            Note = "This is a Company invoice.",
                            Total = 199.95m
                        },
                        new
                        {
                            Id = new Guid("84505bb2-4175-4aa1-8a10-ea151a4bd234"),
                            Note = "This is a Company invoice.",
                            Total = 199.95m
                        },
                        new
                        {
                            Id = new Guid("1c71dd38-7454-47d2-bbb4-88a5fe52e11a"),
                            Note = "This is a Company invoice.",
                            Total = 199.95m
                        });
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityRoleClaim", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityRolePermission", b =>
                {
                    b.HasOne("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityPermission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserClaim", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserLogin", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserRole", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadEyeMatt.AspNetCore.Identity.Permissions.IdentityUserToken", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
