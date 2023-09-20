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
                IdContactoEmpleado = new Guid("319B841C-0573-416A-8754-FCD82AEE04BC"),
                Telefono = 312546845,
                Direccion = "Cra15B #13-52",
                Email = "ContactoE1@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 28),
                EmpleadoId = new Guid("41FFF2B6-9886-40BC-AB38-D34CFAAE3F96")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new Guid("07B892EF-0511-4CF4-B2C6-9CC4932418DD"),
                Telefono = 315874920,
                Direccion = "Av. 7 de Septiembre #25-10",
                Email = "ContactoE2@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 28),
                EmpleadoId = new Guid("1F03E9DA-4F5A-4C01-A74B-5484A0622A88")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new Guid("66A5C506-CA79-4323-9826-2719D047D961"),
                Telefono = 318657489,
                Direccion = "Calle 24 #18-15",
                Email = "ContactoE3@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 29),
                EmpleadoId = new Guid("AAD28FBF-F3E8-43B2-97D4-9EAB3D59597A")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new Guid("E385B218-E55B-4C17-AE51-58FA9343483E"),
                Telefono = 314985632,
                Direccion = "Cra 10A #5-30",
                Email = "ContactoE4@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 29),
                EmpleadoId = new Guid("06E66A66-1840-4A55-ABCF-475E8218963F")
            },
            new ContactoEmpleado
            {
                IdContactoEmpleado = new Guid("6215BE00-B0A6-4DF5-BF6F-481F8089C441"),
                Telefono = 317654987,
                Direccion = "Cra 20 #8-45",
                Email = "ContactoE5@gmail.com",
                FechaCreacion = new DateTime(2023, 8, 30),
                EmpleadoId = new Guid("DA511896-B59C-4052-9103-6BF83A9F4B0A")
            }
            );
        }
    }
}