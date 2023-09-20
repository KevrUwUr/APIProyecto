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
    public class PerdidaProductoConfiguration : IEntityTypeConfiguration<PerdidaProducto>
    {
        public void Configure(EntityTypeBuilder<PerdidaProducto> builder)
        {
            builder.HasData
                (
                new PerdidaProducto
                {
                    IdPerdida = new Guid("5FFA39BA-FD0E-4556-AEBC-C62D3FCC0823"),
                    ProductoId = new Guid("CE7DC2EA-5931-49A1-8946-9782A5843612"),
                    PrecioUnitario = 300000,
                    Cantidad = 5,
                    Motivo = ("Robo")
                }, 
                new PerdidaProducto
                {
                    IdPerdida = new Guid("556E454F-6AE9-4996-8344-95BD3C76AD36"),
                    ProductoId = new Guid("DD6B62DC-F917-4379-9955-1C244EE78C4B"),
                    PrecioUnitario = 200000,
                    Cantidad = 5,
                    Motivo = ("Roto")
                }, 
                new PerdidaProducto
                {
                    IdPerdida = new Guid("2DABB8F6-C2EF-4C37-8B6D-3F306241D100"),
                    ProductoId = new Guid("EDF59C51-6384-422F-B941-CE879C82DCDC"),
                    PrecioUnitario = 350000,
                    Cantidad = 5,
                    Motivo = ("Mal Estado")
                }, 
                new PerdidaProducto
                {
                    IdPerdida = new Guid("42F9CA61-B335-421B-BC21-DE794A40AED0"),
                    ProductoId = new Guid("30D27E06-251C-4911-819A-59A9A3966F78"),
                    PrecioUnitario = 500000,
                    Cantidad = 5,
                    Motivo = ("Daño")
                }, 
                new PerdidaProducto
                {
                    IdPerdida = new Guid("0A730C0E-C85F-4765-974C-CAFC13AC4F57"),
                    ProductoId = new Guid("8B538521-A513-4F5A-B4E6-AE3C57912499"),
                    PrecioUnitario = 100000,
                    Cantidad = 5,
                    Motivo = ("Perdida")
                }
                );
        }
    }
}
