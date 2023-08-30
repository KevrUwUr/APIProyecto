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
                    IdContactoCliente = new int("98f2fe1d-daca-43ae-8377-7cec5063871c"),
                    NumeroTelefonico = 5614248,
                    IndicativoCiudad = "601",
                    TipoTelefono = "Fijo",
                    Direccion = "Cra 12C #53-08",
                    Ciudad = "Bogotá D.C.",
                    Barrio_Localidad = "Usme",
                    Email = "ContactoC1@gmail.com",
                    IdUsuario = new int("41e399b6-45d2-11ee-be56-0242ac120001")
                },
                new ContactoUsuario
                {
                    IdContactoCliente = new int("db4f2880-d343-4393-9321-9f8fe1f045fe"),
                    NumeroTelefonico = 315874920,
                    IndicativoCiudad = "301",
                    TipoTelefono = "Celular",
                    Direccion = "Av. 7 de Septiembre #25-10",
                    Ciudad = "Medellín",
                    Barrio_Localidad = "El Poblado",
                    Email = "ContactoC2@gmail.com",
                    IdUsuario = new int("41e399b6-45d2-11ee-be56-0242ac120002")
                },
                new ContactoUsuario
                {
                    IdContactoCliente = new int("85642320-2766-49f1-bdf0-1df2894b0e7f"),
                    NumeroTelefonico = 317895623,
                    IndicativoCiudad = "571",
                    TipoTelefono = "Fijo",
                    Direccion = "Calle 24 #18-15",
                    Ciudad = "Cali",
                    Barrio_Localidad = "San Fernando",
                    Email = "ContactoC3@gmail.com",
                    IdUsuario = new int("41e399b6-45d2-11ee-be56-0242ac120003")
                },
                new ContactoUsuario
                {
                    IdContactoCliente = new int("7b8a2a1d-c66c-4ff4-8e3d-c7ad72a4c90a"),
                    NumeroTelefonico = 318564237,
                    IndicativoCiudad = "571",
                    TipoTelefono = "Celular",
                    Direccion = "Cra 10A #5-30",
                    Ciudad = "Cali",
                    Barrio_Localidad = "Granada",
                    Email = "ContactoC4@gmail.com",
                    IdUsuario = new int("41e399b6-45d2-11ee-be56-0242ac120004")
                },
                new ContactoUsuario
                {
                    IdContactoCliente = new int("3e055a8d-33eb-45fb-890e-af843cb8d31d"),
                    NumeroTelefonico = 316547896,
                    IndicativoCiudad = "701",
                    TipoTelefono = "Celular",
                    Direccion = "Cra 20 #8-45",
                    Ciudad = "Cartagena",
                    Barrio_Localidad = "El Laguito",
                    Email = "ContactoC5@gmail.com",
                    IdUsuario = new int("41e399b6-45d2-11ee-be56-0242ac120005")
                }
            );
        }
    }
}
