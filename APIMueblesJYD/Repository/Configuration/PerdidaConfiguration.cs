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
                    IdPerdida = new Guid("359a5169-0142-4c4d-b102-b12b3f17b7ac"),
                    IdEmpleado = new Guid("42e9c125-7a69-4d5f-b3a6-3b0e4c71c8a0"),
                    FechaPerdida = new DateOnly(2023, 06, 21),
                    Estado = 1,
                    Total=300000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120002"),
                    IdEmpleado = new Guid("8b30ee54-33d5-4a59-9c48-c918c213e352"),
                    FechaPerdida = new DateOnly(2023, 06, 21),
                    Estado = 2,
                    Total = 200000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120003"),
                    IdEmpleado = new Guid("7f2d45bb-1c6d-4b1b-9db4-9cfaa2e6b9f5"),
                    FechaPerdida = new DateOnly(2023, 06, 21),
                    Estado = 2,
                    Total = 350000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120004"),
                    IdEmpleado = new Guid("f11e6c8e-5d75-4f7b-b29e-960f47f40e0b"),
                    FechaPerdida = new DateOnly(2023, 06, 21),
                    Estado = 1,
                    Total = 500000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120005"),
                    IdEmpleado = new Guid("9b38ab1d-e3c2-4c79-a33f-8c25eb97f1a1"),
                    FechaPerdida = new DateOnly(2023, 06, 21),
                    Estado = 1,
                    Total = 100000
                }
                );
        }
    }
}
