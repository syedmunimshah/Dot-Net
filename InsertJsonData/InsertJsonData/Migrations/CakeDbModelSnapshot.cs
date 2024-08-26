﻿// <auto-generated />
using InsertJsonData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsertJsonData.Migrations
{
    [DbContext(typeof(CakeDb))]
    partial class CakeDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InsertJsonData.Models.CakeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BatterID")
                        .HasColumnType("int");

                    b.Property<string>("BatterType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CakeId")
                        .HasColumnType("int");

                    b.Property<string>("CakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CakePpu")
                        .HasColumnType("float");

                    b.Property<string>("CakeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToppingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToppingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cake");
                });
#pragma warning restore 612, 618
        }
    }
}