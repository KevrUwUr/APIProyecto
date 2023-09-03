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
                    IdContactoCliente = 1,
                    NumeroTelefonico = 5614248,
                    IndicativoCiudad = "601",
                    TipoTelefono = "Fijo",
                    Direccion = "Cra 12C #53-08",
                    Ciudad = "Bogotá D.C.",
                    Barrio_Localidad = "Usme",
                    Email = "ContactoC1@gmail.com",
                    IdUsuario = 1
                },
                new ContactoUsuario
                {
                    IdContactoCliente = 2,
                    NumeroTelefonico = 315874920,
                    IndicativoCiudad = "301",
                    TipoTelefono = "Celular",
                    Direccion = "Av. 7 de Septiembre #25-10",
                    Ciudad = "Medellín",
                    Barrio_Localidad = "El Poblado",
                    Email = "ContactoC2@gmail.com",
                    IdUsuario = 2
                },
                new ContactoUsuario
                {
                    IdContactoCliente = 3,
                    NumeroTelefonico = 317895623,
                    IndicativoCiudad = "571",
                    TipoTelefono = "Fijo",
                    Direccion = "Calle 24 #18-15",
                    Ciudad = "Cali",
                    Barrio_Localidad = "San Fernando",
                    Email = "ContactoC3@gmail.com",
                    IdUsuario = 3
                },
                new ContactoUsuario
                {
                    IdContactoCliente = 4,
                    NumeroTelefonico = 318564237,
                    IndicativoCiudad = "571",
                    TipoTelefono = "Celular",
                    Direccion = "Cra 10A #5-30",
                    Ciudad = "Cali",
                    Barrio_Localidad = "Granada",
                    Email = "ContactoC4@gmail.com",
                    IdUsuario = 4
                }
            );
        }
    }
}
