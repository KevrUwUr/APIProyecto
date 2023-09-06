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
                    IdUsuario = new Guid("1449F86E-3988-43C6-9210-252136156E7E"),
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
                    IdUsuario = new Guid("FD1820F2-B0F0-47A0-AF34-D6D465734F65"),
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
                    IdUsuario = new Guid("E0AAC839-D3E4-4B5C-9B6E-DBF0303DB2B2"),
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
                    IdUsuario = new Guid("58D04FC7-E269-4E8B-AEA4-3F6DA3FEA9BC"),
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
                    IdUsuario = new Guid("E5F2ABB9-BCD0-422B-9E8C-9597BB21BEC1"),
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
