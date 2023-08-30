using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIRestProyecto.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "IdCargo", "Estado", "NombreCargo" },
                values: new object[,]
                {
                    { new int("2954f19b-36e5-4a69-996b-dc3911df74b2"), 1, "Vendedor de Muebles" },
                    { new int("8d8330ee-16ed-41ba-89d3-599651cddb34"), 1, "Técnico de Acabados" },
                    { new int("ef3f0aae-804f-4e7c-9633-212a439d0960"), 1, "Diseñador de Muebles" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "IdCargo",
                keyValue: new int("2954f19b-36e5-4a69-996b-dc3911df74b2"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "IdCargo",
                keyValue: new int("8d8330ee-16ed-41ba-89d3-599651cddb34"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "IdCargo",
                keyValue: new int("ef3f0aae-804f-4e7c-9633-212a439d0960"));
        }
    }
}
