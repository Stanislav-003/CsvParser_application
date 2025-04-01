﻿// <auto-generated />
using System;
using CsvParser_App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CsvParser_App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CsvParser_App.Entity.CsvDataFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DOLocationID")
                        .HasColumnType("int");

                    b.Property<decimal>("FareAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PULocationID")
                        .HasColumnType("int");

                    b.Property<int>("PassengerCount")
                        .HasColumnType("int");

                    b.Property<string>("StoreAndFwdFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TipAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("TpepDropoffDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("TpepPickupDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("TripDistance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CsvDataFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
