using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ContactoEmpleadoConfiguration : IEntityTypeConfiguration<ContactoEmpleado>
    {
        public void Configure(EntityTypeBuilder<ContactoEmpleado> builder)
        {
            builder.HasData
            (
            new ContactoEmpleado
            {
                IdContactoEmpleado = 1,
                Telefono = 312546845,
                Direccion = "Cra15B #13-52",
                Email = "ContactoE1@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 28),
                IdEmpleado = 1
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = 2,
                Telefono = 315874920,
                Direccion = "Av. 7 de Septiembre #25-10",
                Email = "ContactoE2@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 28),
                IdEmpleado = 2
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = 3,
                Telefono = 318657489,
                Direccion = "Calle 24 #18-15",
                Email = "ContactoE3@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 29),
                IdEmpleado =3
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = 4,
                Telefono = 314985632,
                Direccion = "Cra 10A #5-30",
                Email = "ContactoE4@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 29),
                IdEmpleado = 4
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = 5,
                Telefono = 317654987,
                Direccion = "Cra 20 #8-45",
                Email = "ContactoE5@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 30),
                IdEmpleado = 5
            }
            );
        }
    }
}