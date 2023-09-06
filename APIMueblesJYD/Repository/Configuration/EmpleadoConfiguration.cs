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
                    EmpleadoId = new Guid("41FFF2B6-9886-40BC-AB38-D34CFAAE3F96"),
                    Nombres = "Ana María",
                    Apellidos = "González",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateTime(1995, 5, 15),
                    Estado = 1,
                },

                new Empleado
                {
                    EmpleadoId = new Guid("1F03E9DA-4F5A-4C01-A74B-5484A0622A88"),
                    Nombres = "Carlos Alberto",
                    Apellidos = "Ramírez",
                    Sexo = "Masculino",
                    FechaNacimiento = new DateTime(1987, 8, 27),
                    Estado = 1,
                },

                new Empleado
                {
                    EmpleadoId = new Guid("AAD28FBF-F3E8-43B2-97D4-9EAB3D59597A"),
                    Nombres = "Laura",
                    Apellidos = "López",
                    Sexo = "Femenino",
                    FechaNacimiento = new DateTime(1999, 2, 10),
                    Estado = 1,
                },

                new Empleado
                {
                    EmpleadoId = new Guid("06E66A66-1840-4A55-ABCF-475E8218963F"),
                    Nombres = "Roberto",
                    Apellidos = "Hernández",
                    Sexo = "Masculino",
                    FechaNacimiento = new DateTime(1983, 11, 8),
                    Estado = 1,
                },

                new Empleado
                {
                    EmpleadoId = new Guid("DA511896-B59C-4052-9103-6BF83A9F4B0A"),
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
