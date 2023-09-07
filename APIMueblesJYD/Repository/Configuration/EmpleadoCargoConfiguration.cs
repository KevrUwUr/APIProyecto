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
    public class EmpleadoCargoConfiguration : IEntityTypeConfiguration<EmpleadoCargo>
    {
        public void Configure(EntityTypeBuilder<EmpleadoCargo> builder)
        {
            builder.HasData
            (
            new EmpleadoCargo
            {
                EmpleadoCargoId = new Guid("90F05CD7-6F17-460C-9BCB-3C63CE3A4410"),
                FechaInicio = new DateTime(1995, 5, 15),
                FechaFin = new DateTime(2015, 5, 15),
                NumeroContrato = 1,
                CargoId = new Guid("5E74A02D-A99F-40E3-8C4C-A4C58A78AD04"),
                EmpleadoId = new Guid("41FFF2B6-9886-40BC-AB38-D34CFAAE3F96")
            },
            new EmpleadoCargo
            {
                EmpleadoCargoId = new Guid("50A17A3D-D802-4C47-9BDD-2FAD36872396"),
                FechaInicio = new DateTime(2000, 10, 03),
                FechaFin = new DateTime(2010, 12, 31),
                NumeroContrato = 2,
                CargoId = new Guid("1CB1DE39-40FE-472B-BDB7-D37DB36387FB"),
                EmpleadoId = new Guid("1F03E9DA-4F5A-4C01-A74B-5484A0622A88")
            },

            new EmpleadoCargo
            {
                EmpleadoCargoId = new Guid("A7EE5FB7-DEE6-4B4E-91C8-B13364295B26"),
                FechaInicio = new DateTime(2005, 3, 20),
                FechaFin = new DateTime(2010, 12, 31),
                NumeroContrato = 3,
                CargoId = new Guid("24254AC3-4379-41BA-AB1D-D4C31FFC4855"),
                EmpleadoId = new Guid("AAD28FBF-F3E8-43B2-97D4-9EAB3D59597A")
            },

            new EmpleadoCargo
            {
                EmpleadoCargoId = new Guid("76BF7CAD-C62D-4D64-A0C8-B85287300BCE"),
                FechaInicio = new DateTime(2012, 8, 10),
                FechaFin = new DateTime(2010, 12, 31),
                NumeroContrato = 4,
                CargoId = new Guid("8D9B73EC-049B-483A-8D48-36E29C25021E"),
                EmpleadoId = new Guid("06E66A66-1840-4A55-ABCF-475E8218963F")
            },

            new EmpleadoCargo
            {
                EmpleadoCargoId = new Guid("DBCC8132-59F5-4DF7-9AD8-A43C73F3E3A0"),
                FechaInicio = new DateTime(2010, 6, 15),
                FechaFin = new DateTime(2018, 9, 30),
                NumeroContrato = 5,
                CargoId = new Guid("201B4CC5-5647-44B8-8664-08F49C8EBCF6"),
                EmpleadoId = new Guid("DA511896-B59C-4052-9103-6BF83A9F4B0A")
            });

        }
    }
}
