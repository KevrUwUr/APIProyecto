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
                    IdPerdida = new int("0081fd32-45d7-11ee-be56-0242ac120001"),
                    //IdProducto = new int("f6733487-0563-461d-b6f0-78b9de803061"),
                    IdProducto = new int("3e32e739-f4e0-4b3a-8748-118fc4de366b"),
                    PrecioUnitario = 30000,
                    Cantidad = 5,
                    Motivo = ("Robo")
                }, new Perdida_Producto
                {
                    IdPerdida = new int("0081fd32-45d7-11ee-be56-0242ac120002"),
                    //IdProducto = new int("f6733487-0563-461d-b6f0-78b9de803062"),
                    IdProducto = new int("6fc03e94-7f4b-47cc-9df4-73ecaa6ce244"),
                    PrecioUnitario = 20000,
                    Cantidad = 5,
                    Motivo = ("Roto")
                }, new Perdida_Producto
                {
                    IdPerdida = new int("0081fd32-45d7-11ee-be56-0242ac120003"),
                    //IdProducto = new int("f6733487-0563-461d-b6f0-78b9de803063"),
                    IdProducto = new int("3e242bb6-8959-4b53-933b-c9397d11d0d0"),
                    PrecioUnitario = 35000,
                    Cantidad = 5,
                    Motivo = ("Mal Estado")
                }, new Perdida_Producto
                {
                    IdPerdida = new int("0081fd32-45d7-11ee-be56-0242ac120004"),
                    //IdProducto = new int("f6733487-0563-461d-b6f0-78b9de803064"),
                    IdProducto = new int("7ef6aa54-153a-4d94-af65-139d11f5f0f3"),
                    PrecioUnitario = 50000,
                    Cantidad = 5,
                    Motivo = ("Daño")
                }, new Perdida_Producto
                {
                    IdPerdida = new int("d994f932-cb57-4ff7-8b01-81c12d3ed16b"),
                    //IdProducto = new int("f6733487-0563-461d-b6f0-78b9de803065"),
                    IdProducto = new int("f6733487-0563-461d-b6f0-78b9de803061"),
                    PrecioUnitario = 10000,
                    Cantidad = 5,
                    Motivo = ("Perdida")
                }
                );
        }
    }
}
