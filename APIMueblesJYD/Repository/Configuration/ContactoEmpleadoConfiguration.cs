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
                IdContactoEmpleado = new int("bc598efa-4d37-45d3-9a95-89bf95450bb1"),
                Telefono = 312546845,
                Direccion = "Cra15B #13-52",
                Email = "ContactoE1@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 28),
                IdEmpleado = new int("359a5169-0142-4c4d-b102-b12b3f17b7ac")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new int("e5fe6d3a-986d-4f28-b7c6-8f723e9d579b"),
                Telefono = 315874920,
                Direccion = "Av. 7 de Septiembre #25-10",
                Email = "ContactoE2@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 28),
                IdEmpleado = new int("42e9c125-7a69-4d5f-b3a6-3b0e4c71c8a0")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new int("4a30d85b-3e0c-4c75-9c3e-3612ebf16045"),
                Telefono = 318657489,
                Direccion = "Calle 24 #18-15",
                Email = "ContactoE3@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 29),
                IdEmpleado = new int("7f2d45bb-1c6d-4b1b-9db4-9cfaa2e6b9f5")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new int("8e842db5-5123-4df3-8ff9-450a75a5d7a9"),
                Telefono = 314985632,
                Direccion = "Cra 10A #5-30",
                Email = "ContactoE4@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 29),
                IdEmpleado = new int("f11e6c8e-5d75-4f7b-b29e-960f47f40e0b")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new int("d2485f5e-7e47-4b7a-bc42-e829c71fb4e1"),
                Telefono = 317654987,
                Direccion = "Cra 20 #8-45",
                Email = "ContactoE5@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 30),
                IdEmpleado = new int("9b38ab1d-e3c2-4c79-a33f-8c25eb97f1a1")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new int("f9f21d6e-721a-4843-aeff-01c7340f0e9d"),
                Telefono = 310987654,
                Direccion = "Av. Libertadores #45-67",
                Email = "ContactoE6@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 30),
                IdEmpleado = new int("628a9e86-03e0-4e9c-8c0b-4f1c7cbe8a5d")
            }
            );
        }
    }
}