﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace APIRestProyecto.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230828012347_M3")]
    partial class M3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Cargo", b =>
                {
                    b.Property<int>("IdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdCargo");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("NombreCargo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdCargo");

                    b.ToTable("Cargos");

                    b.HasData(
                        new
                        {
                            IdCargo = new int("81ef2c34-7eb7-4891-8e5b-172e5786e687"),
                            Estado = 1,
                            NombreCargo = "Carpintero"
                        },
                        new
                        {
                            IdCargo = new int("ef3f0aae-804f-4e7c-9633-212a439d0960"),
                            Estado = 1,
                            NombreCargo = "Diseñador de Muebles"
                        },
                        new
                        {
                            IdCargo = new int("2954f19b-36e5-4a69-996b-dc3911df74b2"),
                            Estado = 1,
                            NombreCargo = "Vendedor de Muebles"
                        },
                        new
                        {
                            IdCargo = new int("8d8330ee-16ed-41ba-89d3-599651cddb34"),
                            Estado = 1,
                            NombreCargo = "Técnico de Acabados"
                        },
                        new
                        {
                            IdCargo = new int("2d2df54e-e3ff-45e3-915d-ac2f53d371f2"),
                            Estado = 1,
                            NombreCargo = "Asistente de carpinteria"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
