using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class EmpleadoConfiguration
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasData
            (
                new Empleado
                {
                    IdEmpleado = new Guid("359a5169-0142-4c4d-b102-b12b3f17b7ac"),
                    Nombres = "Ana María",
                    Apellidos = "González",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateOnly(1995, 5, 15),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = new Guid("42e9c125-7a69-4d5f-b3a6-3b0e4c71c8a0"),
                    Nombres = "Carlos Alberto",
                    Apellidos = "Ramírez",
                    Sexo = "Masculino",
                    FechaNacimiento = new DateOnly(1987, 8, 27),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = new Guid("7f2d45bb-1c6d-4b1b-9db4-9cfaa2e6b9f5"),
                    Nombres = "Laura",
                    Apellidos = "López",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateOnly(1999, 2, 10),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = new Guid("f11e6c8e-5d75-4f7b-b29e-960f47f40e0b"),
                    Nombres = "Roberto",
                    Apellidos = "Hernández",
                    Sexo = "Masculino",
                    FechaNacimiento = new DateOnly(1983, 11, 8),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = new Guid("9b38ab1d-e3c2-4c79-a33f-8c25eb97f1a1"),
                    Nombres = "María José",
                    Apellidos = "Martínez",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateOnly(2001, 7, 23),
                    Estado = 1,
                },

                new Empleado
                {
                    IdEmpleado = new Guid("628a9e86-03e0-4e9c-8c0b-4f1c7cbe8a5d"),
                    Nombres = "Juan",
                    Apellidos = "Pérez",
                    Sexo = "Masculino",
                    FechaNacimiento = new DateOnly(1990, 4, 5),
                    Estado = 1,
                }
            );
           
        }
    }
}
