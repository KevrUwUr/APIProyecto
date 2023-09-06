using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIRestProyecto.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCargo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimNombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SegNombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PrimApellido = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SegApellido = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NumDocumento = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaContrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Llave = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    OrigenMateriaPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactoEmpleados",
                columns: table => new
                {
                    IdContactoEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoEmpleados", x => x.IdContactoEmpleado);
                    table.ForeignKey(
                        name: "FK_ContactoEmpleados_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoCargos",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroContrato = table.Column<int>(type: "int", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoCargos", x => new { x.EmpleadoId, x.CargoId });
                    table.ForeignKey(
                        name: "FK_EmpleadoCargos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoCargos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perdida",
                columns: table => new
                {
                    IdPerdida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPerdida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perdida", x => x.IdPerdida);
                    table.ForeignKey(
                        name: "FK_Perdida_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactoProveedorConfigurations",
                columns: table => new
                {
                    IdContactoProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProv = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoProveedorConfigurations", x => x.IdContactoProveedor);
                    table.ForeignKey(
                        name: "FK_ContactoProveedorConfigurations_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturasCompras",
                columns: table => new
                {
                    FacturaCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NFactura = table.Column<int>(type: "int", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBruto = table.Column<float>(type: "real", nullable: false),
                    TotalIVA = table.Column<float>(type: "real", nullable: false),
                    TotalRefuete = table.Column<float>(type: "real", nullable: false),
                    TotalPago = table.Column<float>(type: "real", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    ProveedoresIdProveedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasCompras", x => x.FacturaCompraId);
                    table.ForeignKey(
                        name: "FK_FacturasCompras_Proveedores_ProveedoresIdProveedor",
                        column: x => x.ProveedoresIdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor");
                });

            migrationBuilder.CreateTable(
                name: "ContactoUsuarioConfigurations",
                columns: table => new
                {
                    IdContactoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTelefonico = table.Column<int>(type: "int", nullable: false),
                    IndicativoCiudad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TipoTelefono = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Barrio_Localidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoUsuarioConfigurations", x => x.IdContactoCliente);
                    table.ForeignKey(
                        name: "FK_ContactoUsuarioConfigurations_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturasVentas",
                columns: table => new
                {
                    FacturaVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NFactura = table.Column<int>(type: "int", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBruto = table.Column<float>(type: "real", nullable: false),
                    TotalIVA = table.Column<float>(type: "real", nullable: false),
                    TotalRefuete = table.Column<float>(type: "real", nullable: false),
                    TotalPago = table.Column<float>(type: "real", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasVentas", x => x.FacturaVentaId);
                    table.ForeignKey(
                        name: "FK_FacturasVentas_Usuarios_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "HistoricosPrecios",
                columns: table => new
                {
                    IdHistoricoPrecios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioVenta = table.Column<float>(type: "real", nullable: false),
                    FechaPrecioInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPrecioFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosPrecios", x => x.IdHistoricoPrecios);
                    table.ForeignKey(
                        name: "FK_HistoricosPrecios_Productos_IdProducto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perdida_Productos",
                columns: table => new
                {
                    IdPerdida = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perdida_Productos", x => new { x.IdPerdida, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_Perdida_Productos_Perdida_IdPerdida",
                        column: x => x.IdPerdida,
                        principalTable: "Perdida",
                        principalColumn: "IdPerdida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perdida_Productos_Productos_IdProducto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturaCompra",
                columns: table => new
                {
                    DetalleacturaCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    FacturaCompraId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturaCompra", x => x.DetalleacturaCompraId);
                    table.ForeignKey(
                        name: "FK_DetalleFacturaCompra_FacturasCompras_IdFacturaCompra",
                        column: x => x.FacturaCompraId,
                        principalTable: "FacturasCompras",
                        principalColumn: "FacturaCompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFacturaCompra_Productos_IdProducto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFacturaVentas",
                columns: table => new
                {
                    DetalleFacturaVentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    FacturaVentaId = table.Column<int>(type: "int", nullable: false),
                    FacturasVentaIdFacturaVenta = table.Column<int>(type: "int", nullable: true),
                    FacturaCompraIdFacturaCompra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaVentas", x => x.DetalleFacturaVentaID);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_FacturasCompras_FacturaCompraIdFacturaCompra",
                        column: x => x.FacturaCompraIdFacturaCompra,
                        principalTable: "FacturasCompras",
                        principalColumn: "FacturaCompraId");
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_FacturasVentas_FacturasVentaIdFacturaVenta",
                        column: x => x.FacturasVentaIdFacturaVenta,
                        principalTable: "FacturasVentas",
                        principalColumn: "FacturaVentaId");
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_Productos_IdProducto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaTransaccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    NombrePlataforma = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FacturaVentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.IdMetodoPago);
                    table.ForeignKey(
                        name: "FK_MetodoPagos_FacturasVentas_IdFacturaVenta",
                        column: x => x.FacturaVentaId,
                        principalTable: "FacturasVentas",
                        principalColumn: "FacturaVentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "CargoId", "Estado", "NombreCargo" },
                values: new object[,]
                {
                    { 1, 1, "Carpintero" },
                    { 2, 1, "Diseñador de Muebles" },
                    { 3, 1, "Vendedor de Muebles" },
                    { 4, 1, "Técnico de Acabados" },
                    { 5, 1, "Asistente de carpinteria" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Muebles" },
                    { 2, 1, "Camas" },
                    { 3, 1, "Mesas de Noche" },
                    { 4, 1, "Comedores" },
                    { 5, 1, "Escritorios" },
                    { 6, 1, "Sillas" },
                    { 7, 1, "Armarios" },
                    { 8, 1, "Camarotes" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellidos", "Estado", "FechaNacimiento", "Nombres", "Sexo" },
                values: new object[,]
                {
                    { 1, "González", 1, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana María", "Femenino" },
                    { 2, "Ramírez", 1, new DateTime(1987, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Alberto", "Masculino" },
                    { 3, "López", 1, new DateTime(1999, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Femenino" },
                    { 4, "Hernández", 1, new DateTime(1983, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", "Masculino" },
                    { 5, "Martínez", 1, new DateTime(2001, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "María José", "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "FacturasCompras",
                columns: new[] { "FacturaCompraId", "FechaExpedicion", "FechaGeneracion", "FechaVencimiento", "IdProveedor", "NFactura", "ProveedoresIdProveedor", "TotalBruto", "TotalIVA", "TotalPago", "TotalRefuete" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 100000f, 19000f, 139000f, 20000f },
                    { 2, new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null, 150000f, 2850f, 182850f, 30000f }
                });

            migrationBuilder.InsertData(
                table: "FacturasVentas",
                columns: new[] { "FacturaVentaId", "FechaExpedicion", "FechaGeneracion", "FechaVencimiento", "IdUsuario", "NFactura", "TotalBruto", "TotalIVA", "TotalPago", "TotalRefuete", "UsuariosIdUsuario" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 85000f, 16150f, 113150f, 12000f, null },
                    { 2, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 120000f, 22800f, 157800f, 15000f, null }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "IdProveedor", "Estado", "RazonSocial" },
                values: new object[,]
                {
                    { 1, 1, "La Guitarra, S.A" },
                    { 2, 1, "Sol Dorado" },
                    { 3, 1, "Marena" },
                    { 4, 1, "Juguetes Vikingos" },
                    { 5, 2, "Lima & Álvarez" },
                    { 6, 1, "Arcos Dorados, C.A" },
                    { 7, 1, "Carlos Fernández, E.I.R" },
                    { 8, 1, "Chascomús, S.A" },
                    { 9, 2, "Grupo Fernández S.A" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Cargo", "Contrasena", "Estado", "FechaContrato", "FechaFin", "FechaNacimiento", "FechaRegistro", "Llave", "NumDocumento", "PrimApellido", "PrimNombre", "SegApellido", "SegNombre", "Sexo", "TipoDocumento", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "Administrador", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1019762822, "Marin", "Kevin", "Hoyos", "Alejandro", "Masculino", "C.C", 1 },
                    { 2, "Carpintero", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1013100300, "Sarmiento", "Miguel", "Mojica", "Angel", "Masculino", "C.C", 1 },
                    { 3, "Supervisor de Producción", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1025445665, "Ramirez", "David", "Martin", "Felipe", "Masculino", "C.C", 1 },
                    { 4, "Asistente de carpinteria", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1013265449, "Velez", "Maria", "Wedderburn", "Fernanda", "Femenino", "C.C", 1 },
                    { 5, "Encargado de almacén", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1016598778, "Rivera", "Lizeth", "Ruiz", "Valeria", "Femenino", "C.C", 1 }
                });

            migrationBuilder.InsertData(
                table: "ContactoEmpleados",
                columns: new[] { "IdContactoEmpleado", "Direccion", "Email", "EmpleadoId", "FechaCreacion", "Telefono" },
                values: new object[,]
                {
                    { 1, "Cra15B #13-52", "ContactoE1@gmail.com", 1, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 312546845 },
                    { 2, "Av. 7 de Septiembre #25-10", "ContactoE2@gmail.com", 2, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 315874920 },
                    { 3, "Calle 24 #18-15", "ContactoE3@gmail.com", 3, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 318657489 },
                    { 4, "Cra 10A #5-30", "ContactoE4@gmail.com", 4, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 314985632 },
                    { 5, "Cra 20 #8-45", "ContactoE5@gmail.com", 5, new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 317654987 }
                });

            migrationBuilder.InsertData(
                table: "ContactoProveedorConfigurations",
                columns: new[] { "IdContactoProveedor", "Email", "Estado", "FechaAlta", "FechaBaja", "IdProveedor", "NombreProv", "Telefono" },
                values: new object[,]
                {
                    { 1, "ContactP1@gmail.com", 1, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sam Raiden", 314526948 },
                    { 2, "ContactP2@gmail.com", 1, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Laura Montoya", 310987654 },
                    { 3, "ContactP3@gmail.com", 2, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Carlos Rivera", 317895623 },
                    { 4, "ContactP4@gmail.com", 1, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Elena Gómez", 312589764 },
                    { 5, "ContactP5@gmail.com", 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Ana Martínez", 319875634 },
                    { 6, "ContactP6@gmail.com", 1, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Juan Soto", 316547896 },
                    { 7, "ContactP7@gmail.com", 1, new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "María Salas", 318564237 },
                    { 8, "ContactP8@gmail.com", 2, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Luis Gutiérrez", 313258741 },
                    { 9, "ContactP9@gmail.com", 1, new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Fernando López", 317896542 }
                });

            migrationBuilder.InsertData(
                table: "ContactoUsuarioConfigurations",
                columns: new[] { "IdContactoCliente", "Barrio_Localidad", "Ciudad", "Direccion", "Email", "IdUsuario", "IndicativoCiudad", "NumeroTelefonico", "TipoTelefono" },
                values: new object[,]
                {
                    { 1, "Usme", "Bogotá D.C.", "Cra 12C #53-08", "ContactoC1@gmail.com", 1, "601", 5614248, "Fijo" },
                    { 2, "El Poblado", "Medellín", "Av. 7 de Septiembre #25-10", "ContactoC2@gmail.com", 2, "301", 315874920, "Celular" },
                    { 3, "San Fernando", "Cali", "Calle 24 #18-15", "ContactoC3@gmail.com", 3, "571", 317895623, "Fijo" },
                    { 4, "Granada", "Cali", "Cra 10A #5-30", "ContactoC4@gmail.com", 4, "571", 318564237, "Celular" }
                });

            migrationBuilder.InsertData(
                table: "EmpleadoCargos",
                columns: new[] { "CargoId", "EmpleadoId", "FechaFin", "FechaInicio", "NumeroContrato" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "MetodoPagos",
                columns: new[] { "IdMetodoPago", "FechaTransaccion", "FacturaVentaId", "NombrePlataforma", "Tipo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nequi", 2 },
                    { 2, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Daviplata", 2 }
                });

            migrationBuilder.InsertData(
                table: "Perdida",
                columns: new[] { "IdPerdida", "EmpleadoId", "Estado", "FechaPerdida", "Total" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 300000f },
                    { 2, 2, 2, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000f },
                    { 3, 3, 2, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 350000f },
                    { 4, 4, 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 500000f },
                    { 5, 5, 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000f }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Color", "Descripcion", "Estado", "IdCategoria", "Nombre", "OrigenMateriaPrima", "Precio", "Stock", "Tipo" },
                values: new object[,]
                {
                    { 1, "Blanco", "Cama doble de madera", 1, 1, "Cama doble", null, 500000f, 3, 2 },
                    { 2, "Negro", "Mesa de noche de estilo moderno", 1, 2, "Mesa de noche", null, 150000f, 5, 2 },
                    { 3, "Marrón", "Comedor de madera con capacidad para 6 personas", 1, 3, "Comedor extensible", null, 800000f, 2, 1 },
                    { 4, "Gris", "Silla cómoda con soporte lumbar", 1, 4, "Silla ergonómica", null, 250000f, 8, 2 },
                    { 5, "Blanco", "Escritorio de diseño minimalista", 1, 5, "Escritorio moderno", null, 350000f, 4, 1 },
                    { 6, "Café", "Armario espacioso con compartimentos", 1, 6, "Armario de 4 puertas", null, 700000f, 1, 1 },
                    { 7, "Azul", "Camarote con temática de caricaturas", 1, 7, "Camarote infantil", null, 450000f, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "DetalleFacturaCompra",
                columns: new[] { "DetalleacturaCompraId", "Cantidad", "IVA", "FacturaCompraId", "ProductoId", "ValorDescuento", "ValorUnitario" },
                values: new object[,]
                {
                    { 1, 2, 0.3f, 1, 1, 0.05f, 250000f },
                    { 2, 4, 0.3f, 2, 2, 0.05f, 500000f }
                });

            migrationBuilder.InsertData(
                table: "DetallesFacturaVentas",
                columns: new[] { "DetalleFacturaVentaID", "Cantidad", "FacturaCompraIdFacturaCompra", "FacturasVentaIdFacturaVenta", "IVA", "FacturaVentaId", "ProductoId", "ValorDescuento", "ValorUnitario" },
                values: new object[,]
                {
                    { 1, 2, null, null, 8075f, 1, 1, 0f, 42500f },
                    { 2, 2, null, null, 1534f, 2, 2, 0f, 60000f }
                });

            migrationBuilder.InsertData(
                table: "HistoricosPrecios",
                columns: new[] { "IdHistoricoPrecios", "Estado", "FechaPrecioFinal", "FechaPrecioInicial", "ProductoId", "PrecioVenta" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 42500f },
                    { 2, 1, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 60000f },
                    { 3, 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 38500f },
                    { 4, 1, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 50000f },
                    { 5, 1, new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 70000f },
                    { 6, 1, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 55000f },
                    { 7, 1, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 42000f }
                });

            migrationBuilder.InsertData(
                table: "Perdida_Productos",
                columns: new[] { "IdPerdida", "ProductoId", "Cantidad", "Motivo", "PrecioUnitario" },
                values: new object[,]
                {
                    { 1, 1, 5, "Robo", 30000f },
                    { 2, 2, 5, "Roto", 20000f },
                    { 3, 3, 5, "Mal Estado", 35000f },
                    { 4, 4, 5, "Daño", 50000f },
                    { 5, 5, 5, "Perdida", 10000f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactoEmpleados_EmpleadoId",
                table: "ContactoEmpleados",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoProveedorConfigurations_IdProveedor",
                table: "ContactoProveedorConfigurations",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoUsuarioConfigurations_IdUsuario",
                table: "ContactoUsuarioConfigurations",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturaCompra_IdFacturaCompra",
                table: "DetalleFacturaCompra",
                column: "FacturaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturaCompra_IdProducto",
                table: "DetalleFacturaCompra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_FacturaCompraIdFacturaCompra",
                table: "DetallesFacturaVentas",
                column: "FacturaCompraIdFacturaCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_FacturasVentaIdFacturaVenta",
                table: "DetallesFacturaVentas",
                column: "FacturasVentaIdFacturaVenta");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_IdProducto",
                table: "DetallesFacturaVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoCargos_CargoId",
                table: "EmpleadoCargos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasCompras_ProveedoresIdProveedor",
                table: "FacturasCompras",
                column: "ProveedoresIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasVentas_UsuariosIdUsuario",
                table: "FacturasVentas",
                column: "UsuariosIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosPrecios_IdProducto",
                table: "HistoricosPrecios",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPagos_IdFacturaVenta",
                table: "MetodoPagos",
                column: "FacturaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perdida_EmpleadoId",
                table: "Perdida",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perdida_Productos_IdProducto",
                table: "Perdida_Productos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactoEmpleados");

            migrationBuilder.DropTable(
                name: "ContactoProveedorConfigurations");

            migrationBuilder.DropTable(
                name: "ContactoUsuarioConfigurations");

            migrationBuilder.DropTable(
                name: "DetalleFacturaCompra");

            migrationBuilder.DropTable(
                name: "DetallesFacturaVentas");

            migrationBuilder.DropTable(
                name: "EmpleadoCargos");

            migrationBuilder.DropTable(
                name: "HistoricosPrecios");

            migrationBuilder.DropTable(
                name: "MetodoPagos");

            migrationBuilder.DropTable(
                name: "Perdida_Productos");

            migrationBuilder.DropTable(
                name: "FacturasCompras");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "FacturasVentas");

            migrationBuilder.DropTable(
                name: "Perdida");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
