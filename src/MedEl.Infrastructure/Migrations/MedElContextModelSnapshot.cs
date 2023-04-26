﻿// <auto-generated />
using System;
using MedEl.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedEl.Infrastructure.Migrations
{
    [DbContext(typeof(MedElContext))]
    partial class MedElContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedEl.Domain.Models.Tires.TireSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Pressure")
                        .HasColumnType("real");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TireSets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TireSet");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MedEl.Domain.Models.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vehicle");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MedEl.Domain.Models.Tires.SummerTireSet", b =>
                {
                    b.HasBaseType("MedEl.Domain.Models.Tires.TireSet");

                    b.Property<float>("MaximumTemperature")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("SummerTireSet");
                });

            modelBuilder.Entity("MedEl.Domain.Models.Tires.WinterTireSet", b =>
                {
                    b.HasBaseType("MedEl.Domain.Models.Tires.TireSet");

                    b.Property<float>("MinimumTemperature")
                        .HasColumnType("real");

                    b.Property<float>("Thickness")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("WinterTireSet");
                });

            modelBuilder.Entity("MedEl.Domain.Models.Vehicles.Car", b =>
                {
                    b.HasBaseType("MedEl.Domain.Models.Vehicles.Vehicle");

                    b.Property<int?>("TiresId")
                        .HasColumnType("integer");

                    b.HasIndex("TiresId");

                    b.HasDiscriminator().HasValue("Car");
                });

            modelBuilder.Entity("MedEl.Domain.Models.Vehicles.Motorcycle", b =>
                {
                    b.HasBaseType("MedEl.Domain.Models.Vehicles.Vehicle");

                    b.HasDiscriminator().HasValue("Motorcycle");
                });

            modelBuilder.Entity("MedEl.Domain.Models.Vehicles.Car", b =>
                {
                    b.HasOne("MedEl.Domain.Models.Tires.TireSet", "Tires")
                        .WithMany()
                        .HasForeignKey("TiresId");

                    b.Navigation("Tires");
                });
#pragma warning restore 612, 618
        }
    }
}