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
    public class PerdidaProductoConfiguration : IEntityTypeConfiguration<Perdida_Producto>
    {
        public void Configure(EntityTypeBuilder<Perdida_Producto> builder)
        {
            builder.HasData
                (
                new Perdida_Producto
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120001"),
                    IdProducto = new Guid("f6733487-0563-461d-b6f0-78b9de803061"),
                    PrecioUnitario = 30000,
                    Cantidad = 5,
                    Motivo=("Robo")
                }, new Perdida_Producto
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120002"),
                    IdProducto = new Guid("f6733487-0563-461d-b6f0-78b9de803061"),
                    PrecioUnitario = 20000,
                    Cantidad = 5,
                    Motivo = ("Roto")
                }, new Perdida_Producto
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120003"),
                    IdProducto = new Guid("f6733487-0563-461d-b6f0-78b9de803061"),
                    PrecioUnitario = 35000,
                    Cantidad = 5,
                    Motivo = ("Mal Estado")
                }, new Perdida_Producto
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120004"),
                    IdProducto = new Guid("f6733487-0563-461d-b6f0-78b9de803061"),
                    PrecioUnitario = 50000,
                    Cantidad = 5,
                    Motivo = ("Daño")
                }, new Perdida_Producto
                {
                    IdPerdida = new Guid("0081fd32-45d7-11ee-be56-0242ac120005"),
                    IdProducto = new Guid("f6733487-0563-461d-b6f0-78b9de803061"),
                    PrecioUnitario = 10000,
                    Cantidad = 5,
                    Motivo = ("Perdida")
                }
                );
        }
    }
}
