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
    public class PerdidaConfiguration : IEntityTypeConfiguration<Perdida>
    {
        public void Configure(EntityTypeBuilder<Perdida> builder)
        {
            builder.HasData
                (
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120001"),
                    IdEmpleado = new Guid("8b30ee54-33d5-4a59-9c48-c918c213e351"),
                    FechaPerdida = new DateTime(2023 - 06 - 21),
                    Estado = 1,
                    Total=300000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120002"),
                    IdEmpleado = new Guid("8b30ee54-33d5-4a59-9c48-c918c213e352"),
                    FechaPerdida = new DateTime(2023 - 06 - 21),
                    Estado = 2,
                    Total = 300000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120003"),
                    IdEmpleado = new Guid("8b30ee54-33d5-4a59-9c48-c918c213e353"),
                    FechaPerdida = new DateTime(2023 - 06 - 21),
                    Estado = 2,
                    Total = 300000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120004"),
                    IdEmpleado = new Guid("8b30ee54-33d5-4a59-9c48-c918c213e354"),
                    FechaPerdida = new DateTime(2023 - 06 - 21),
                    Estado = 1,
                    Total = 300000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120005"),
                    IdEmpleado = new Guid("8b30ee54-33d5-4a59-9c48-c918c213e355"),
                    FechaPerdida = new DateTime(2023 - 06 - 21),
                    Estado = 1,
                    Total = 300000
                }
                );
        }
    }
}
