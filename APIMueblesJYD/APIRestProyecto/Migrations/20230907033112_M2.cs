using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRestProyecto.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesFacturaVentas_FacturasCompras_FacturaCompraId",
                table: "DetallesFacturaVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetallesFacturaVentas_FacturaCompraId",
                table: "DetallesFacturaVentas");

            migrationBuilder.DropColumn(
                name: "FacturaCompraId",
                table: "DetallesFacturaVentas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FacturaCompraId",
                table: "DetallesFacturaVentas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DetallesFacturaVentas",
                keyColumn: "DetalleFacturaVentaID",
                keyValue: new Guid("21980b54-0dd3-46b0-b77a-29eb80caa3c8"),
                column: "FacturaCompraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DetallesFacturaVentas",
                keyColumn: "DetalleFacturaVentaID",
                keyValue: new Guid("636e9434-f3aa-44d1-9ef0-8470d72a5bee"),
                column: "FacturaCompraId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_FacturaCompraId",
                table: "DetallesFacturaVentas",
                column: "FacturaCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesFacturaVentas_FacturasCompras_FacturaCompraId",
                table: "DetallesFacturaVentas",
                column: "FacturaCompraId",
                principalTable: "FacturasCompras",
                principalColumn: "FacturaCompraId");
        }
    }
}
