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
                    IdPerdida = new Guid("5FFA39BA-FD0E-4556-AEBC-C62D3FCC0823"),
                    EmpleadoId = new Guid("41FFF2B6-9886-40BC-AB38-D34CFAAE3F96"),
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 1,
                    Total=300000
                },
                new Perdida
                {
                    IdPerdida = new Guid("556E454F-6AE9-4996-8344-95BD3C76AD36"),
                    EmpleadoId = new Guid("1F03E9DA-4F5A-4C01-A74B-5484A0622A88"),
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 2,
                    Total = 200000
                },
                new Perdida
                {
                    IdPerdida = new Guid("2DABB8F6-C2EF-4C37-8B6D-3F306241D100"),
                    EmpleadoId = new Guid("AAD28FBF-F3E8-43B2-97D4-9EAB3D59597A"),
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 2,
                    Total = 350000
                },
                new Perdida
                {
                    IdPerdida = new Guid("42F9CA61-B335-421B-BC21-DE794A40AED0"),
                    EmpleadoId = new Guid("06E66A66-1840-4A55-ABCF-475E8218963F"),
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 1,
                    Total = 500000
                },
                new Perdida
                {
                    IdPerdida = new Guid("0A730C0E-C85F-4765-974C-CAFC13AC4F57"),
                    EmpleadoId = new Guid("DA511896-B59C-4052-9103-6BF83A9F4B0A"),
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 1,
                    Total = 100000
                }
                );
        }
    }
}
