﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleTenant;

#nullable disable

namespace SampleTenant.Migrations.InvoicesDb
{
    [DbContext(typeof(InvoicesDbContext))]
    partial class InvoicesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("invoices")
                .HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("SampleTenant.Model.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("InvoiceTenantIdIndex");

                    b.ToTable("Invoices", "invoices");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e91cad3d-2a48-4e64-aa0a-3929126622a1"),
                            Note = "This is a Startup invoice.",
                            TenantId = "7d706acd-f5fd-4979-9e3f-c77a0bd596b2",
                            Total = 99.95m
                        },
                        new
                        {
                            Id = new Guid("132d142c-b56f-4d2c-954f-3a91491f7e9e"),
                            Note = "This is a Startup invoice.",
                            TenantId = "7d706acd-f5fd-4979-9e3f-c77a0bd596b2",
                            Total = 99.95m
                        },
                        new
                        {
                            Id = new Guid("0f7eecb1-53d2-41f3-bc4d-4fae75433f62"),
                            Note = "This is a Startup invoice.",
                            TenantId = "7d706acd-f5fd-4979-9e3f-c77a0bd596b2",
                            Total = 99.95m
                        },
                        new
                        {
                            Id = new Guid("4ecda8f8-a8a0-4b86-bac7-4d83461f7a13"),
                            Note = "This is a Company invoice.",
                            TenantId = "ee5128d3-4cad-4bcc-aa64-f6abbb30da46",
                            Total = 199.95m
                        },
                        new
                        {
                            Id = new Guid("c40673e6-b69e-40c0-a16d-8b01f04e747b"),
                            Note = "This is a Company invoice.",
                            TenantId = "ee5128d3-4cad-4bcc-aa64-f6abbb30da46",
                            Total = 199.95m
                        },
                        new
                        {
                            Id = new Guid("c4279ed7-9272-4248-a6ce-8196634e71ca"),
                            Note = "This is a Company invoice.",
                            TenantId = "ee5128d3-4cad-4bcc-aa64-f6abbb30da46",
                            Total = 199.95m
                        },
                        new
                        {
                            Id = new Guid("5aff46c9-cb63-4ece-a35e-643c8d0babff"),
                            Note = "This is a Corporate invoice.",
                            TenantId = "49a049d2-23ad-41df-8806-240aebaa2f17",
                            Total = 399.95m
                        },
                        new
                        {
                            Id = new Guid("7fc4111a-ea66-4829-b145-f14e99879d38"),
                            Note = "This is a Corporate invoice.",
                            TenantId = "49a049d2-23ad-41df-8806-240aebaa2f17",
                            Total = 399.95m
                        },
                        new
                        {
                            Id = new Guid("a6b7b5a0-041e-4fd2-89c6-0105a627083a"),
                            Note = "This is a Corporate invoice.",
                            TenantId = "49a049d2-23ad-41df-8806-240aebaa2f17",
                            Total = 399.95m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}