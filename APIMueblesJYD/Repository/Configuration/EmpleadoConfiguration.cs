using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasData
            (
                new Empleado
                {
                    IdEmpleado = 1,
                    Nombres = "Ana María",
                    Apellidos = "González",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateTime(1995, 5, 15),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = 2,
                    Nombres = "Carlos Alberto",
                    Apellidos = "Ramírez",
                    Sexo = "Masculino",
                    FechaNacimiento = new DateTime(1987, 8, 27),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = 3,
                    Nombres = "Laura",
                    Apellidos = "López",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateTime(1999, 2, 10),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = 4,
                    Nombres = "Roberto",
                    Apellidos = "Hernández",
                    Sexo = "Masculino",
                    FechaNacimiento = new DateTime(1983, 11, 8),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado =5,
                    Nombres = "María José",
                    Apellidos = "Martínez",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateTime(2001, 7, 23),
                    Estado = 1,
                }
            );
           
        }
    }
}
