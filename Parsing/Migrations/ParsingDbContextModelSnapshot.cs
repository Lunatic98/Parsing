﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Parsing;

#nullable disable

namespace Parsing.Migrations
{
    [DbContext(typeof(ParsingDbContext))]
    partial class ParsingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Parsing.Deal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BuyerInn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DealDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DealNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SellerInn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Typename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("WoodVolumeBuyer")
                        .HasColumnType("double precision");

                    b.Property<double>("WoodVolumeSeller")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Deals");
                });
#pragma warning restore 612, 618
        }
    }
}
