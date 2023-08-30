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
                    IdPerdida =1,
                    IdProducto = 1,
                    PrecioUnitario = 30000,
                    Cantidad = 5,
                    Motivo = ("Robo")
                }, 
                new Perdida_Producto
                {
                    IdPerdida = 2,
                    IdProducto = 2,
                    PrecioUnitario = 20000,
                    Cantidad = 5,
                    Motivo = ("Roto")
                }, 
                new Perdida_Producto
                {
                    IdPerdida = 3,
                    IdProducto = 3,
                    PrecioUnitario = 35000,
                    Cantidad = 5,
                    Motivo = ("Mal Estado")
                }, 
                new Perdida_Producto
                {
                    IdPerdida = 4,
                    IdProducto = 4,
                    PrecioUnitario = 50000,
                    Cantidad = 5,
                    Motivo = ("Daño")
                }, 
                new Perdida_Producto
                {
                    IdPerdida = 5,
                    IdProducto = 5,
                    PrecioUnitario = 10000,
                    Cantidad = 5,
                    Motivo = ("Perdida")
                }
                );
        }
    }
}
