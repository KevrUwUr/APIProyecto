using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Configuration
{
    public class ContactoUsuarioConfiguration : IEntityTypeConfiguration<ContactoUsuario>
    {
        public void Configure(EntityTypeBuilder<ContactoUsuario> builder)
        {
            builder.HasData
            (
                new ContactoUsuario
                {
                    IdContactoCliente = new Guid("03B22D58-4A3D-4AB1-93D3-143686897A49"),
                    NumeroTelefonico = 5614248,
                    IndicativoCiudad = "601",
                    TipoTelefono = "Fijo",
                    Direccion = "Cra 12C #53-08",
                    Ciudad = "Bogotá D.C.",
                    Barrio_Localidad = "Usme",
                    Email = "ContactoC1@gmail.com",
                    IdUsuario = new Guid("1449F86E-3988-43C6-9210-252136156E7E")
                },
                new ContactoUsuario
                {
                    IdContactoCliente = new Guid("9D1A4BD6-E6EB-40BD-8333-A8745C90AE58"),
                    NumeroTelefonico = 315874920,
                    IndicativoCiudad = "301",
                    TipoTelefono = "Celular",
                    Direccion = "Av. 7 de Septiembre #25-10",
                    Ciudad = "Medellín",
                    Barrio_Localidad = "El Poblado",
                    Email = "ContactoC2@gmail.com",
                    IdUsuario = new Guid("E0AAC839-D3E4-4B5C-9B6E-DBF0303DB2B2")
                },
                new ContactoUsuario
                {
                    IdContactoCliente = new Guid("06DC8C36-D46E-4EB1-97D5-92355BA32B9F"),
                    NumeroTelefonico = 317895623,
                    IndicativoCiudad = "571",
                    TipoTelefono = "Fijo",
                    Direccion = "Calle 24 #18-15",
                    Ciudad = "Cali",
                    Barrio_Localidad = "San Fernando",
                    Email = "ContactoC3@gmail.com",
                    IdUsuario = new Guid("58D04FC7-E269-4E8B-AEA4-3F6DA3FEA9BC")
                },
                new ContactoUsuario
                {
                    IdContactoCliente = new Guid("9F355A72-89F6-47C8-AAAB-931E4D5D40A5"),
                    NumeroTelefonico = 318564237,
                    IndicativoCiudad = "571",
                    TipoTelefono = "Celular",
                    Direccion = "Cra 10A #5-30",
                    Ciudad = "Cali",
                    Barrio_Localidad = "Granada",
                    Email = "ContactoC4@gmail.com",
                    IdUsuario = new Guid("E5F2ABB9-BCD0-422B-9E8C-9597BB21BEC1")
                }
            );
        }
    }
}
