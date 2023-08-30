using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData
                (
                new Usuario
                {
                    IdUsuario = 1,
                    PrimNombre = "Kevin",
                    SegNombre = "Alejandro",
                    PrimApellido = "Marin",
                    SegApellido = "Hoyos",
                    Sexo = "Masculino",
                    TipoDocumento = "C.C",
                    NumDocumento = 1019762822,
                    FechaNacimiento = new DateTime(2000, 06, 21),
                    Estado = 1,
                    FechaRegistro = new DateTime(2023, 06,20),
                    TipoUsuario = 1,
                    FechaContrato = new DateTime(2023, 06, 21),
                    Cargo = "Administrador",
                    FechaFin = new DateTime(2023, 06, 21),
                    Contrasena = "",
                    Llave = "ADSO2558108"
                },
                new Usuario
                {
                    IdUsuario = 2,
                    PrimNombre = "Miguel",
                    SegNombre = "Angel",
                    PrimApellido = "Sarmiento",
                    SegApellido = "Mojica",
                    Sexo = "Masculino",
                    TipoDocumento = "C.C",
                    NumDocumento = 1013100300,
                    FechaNacimiento = new DateTime(2000, 06, 21),
                    Estado = 1,
                    FechaRegistro = new DateTime(2023, 06, 20),
                    TipoUsuario = 1,
                    FechaContrato = new DateTime(2023, 06, 21),
                    Cargo = "Carpintero",
                    FechaFin = new DateTime(2023, 06, 21),
                    Contrasena = "",
                    Llave = "ADSO2558108"
                },
                new Usuario
                {
                    IdUsuario = 3,
                    PrimNombre = "David",
                    SegNombre = "Felipe",
                    PrimApellido = "Ramirez",
                    SegApellido = "Martin",
                    Sexo = "Masculino",
                    TipoDocumento = "C.C",
                    NumDocumento = 1025445665,
                    FechaNacimiento = new DateTime(2000, 06, 21),
                    Estado = 1,
                    FechaRegistro = new DateTime(2023, 06, 20),
                    TipoUsuario = 1,
                    FechaContrato = new DateTime(2023, 06, 21),
                    Cargo = "Supervisor de Producción",
                    FechaFin = new DateTime(2023, 06, 21),
                    Contrasena = "",
                    Llave = "ADSO2558108"
                },
                new Usuario
                {
                    IdUsuario = 4,
                    PrimNombre = "Maria",
                    SegNombre = "Fernanda",
                    PrimApellido = "Velez",
                    SegApellido = "Wedderburn",
                    Sexo = "Femenino",
                    TipoDocumento = "C.C",
                    NumDocumento = 1013265449,
                    FechaNacimiento = new DateTime(2000, 06, 21),
                    Estado = 1,
                    FechaRegistro = new DateTime(2023, 06, 20),
                    TipoUsuario = 1,
                    FechaContrato = new DateTime(2023, 06, 21),
                    Cargo = "Asistente de carpinteria",
                    FechaFin = new DateTime(2023, 06, 21),
                    Contrasena = "",
                    Llave = "ADSO2558108"
                },
                new Usuario
                {
                    IdUsuario = 5,
                    PrimNombre = "Lizeth",
                    SegNombre = "Valeria",
                    PrimApellido = "Rivera",
                    SegApellido = "Ruiz",
                    Sexo = "Femenino",
                    TipoDocumento = "C.C",
                    NumDocumento = 1016598778,
                    FechaNacimiento = new DateTime(2000, 06, 21),
                    Estado = 1,
                    FechaRegistro = new DateTime(2023, 06, 20),
                    TipoUsuario = 1,
                    FechaContrato = new DateTime(2023, 06, 21),
                    Cargo = "Encargado de almacén",
                    FechaFin = new DateTime(2023, 06, 21),
                    Contrasena = "",
                    Llave = "ADSO2558108"
                }
                );
        }
    }
}
