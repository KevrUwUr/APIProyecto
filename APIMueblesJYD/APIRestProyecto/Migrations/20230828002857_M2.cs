using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIRestProyecto.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "IdCargo", "Estado", "NombreCargo" },
                values: new object[,]
                {
                    { new Guid("2d2df54e-e3ff-45e3-915d-ac2f53d371f2"), 1, "Asistente de carpinteria" },
                    { new Guid("81ef2c34-7eb7-4891-8e5b-172e5786e687"), 1, "Carpintero" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "IdCargo",
                keyValue: new Guid("2d2df54e-e3ff-45e3-915d-ac2f53d371f2"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "IdCargo",
                keyValue: new Guid("81ef2c34-7eb7-4891-8e5b-172e5786e687"));
        }
    }
}
