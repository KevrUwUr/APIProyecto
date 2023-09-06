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
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    OrigenMateriaPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    IdContactoEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    IdPerdida = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaPerdida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    IdContactoProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreProv = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    FacturaCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NFactura = table.Column<int>(type: "int", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBruto = table.Column<float>(type: "real", nullable: false),
                    TotalIVA = table.Column<float>(type: "real", nullable: false),
                    TotalRefuete = table.Column<float>(type: "real", nullable: false),
                    TotalPago = table.Column<float>(type: "real", nullable: false),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProveedoresIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    IdContactoCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTelefonico = table.Column<int>(type: "int", nullable: false),
                    IndicativoCiudad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TipoTelefono = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Barrio_Localidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    FacturaVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NFactura = table.Column<int>(type: "int", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBruto = table.Column<float>(type: "real", nullable: false),
                    TotalIVA = table.Column<float>(type: "real", nullable: false),
                    TotalRefuete = table.Column<float>(type: "real", nullable: false),
                    TotalPago = table.Column<float>(type: "real", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    IdHistoricoPrecios = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioVenta = table.Column<float>(type: "real", nullable: false),
                    FechaPrecioInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPrecioFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosPrecios", x => x.IdHistoricoPrecios);
                    table.ForeignKey(
                        name: "FK_HistoricosPrecios_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perdida_Productos",
                columns: table => new
                {
                    IdPerdida = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerdidaProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Perdida_Productos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturaCompra",
                columns: table => new
                {
                    DetalleacturaCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    FacturaCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturaCompra", x => x.DetalleacturaCompraId);
                    table.ForeignKey(
                        name: "FK_DetalleFacturaCompra_FacturasCompras_FacturaCompraId",
                        column: x => x.FacturaCompraId,
                        principalTable: "FacturasCompras",
                        principalColumn: "FacturaCompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFacturaCompra_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFacturaVentas",
                columns: table => new
                {
                    DetalleFacturaVentaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacturaVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacturaCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaVentas", x => x.DetalleFacturaVentaID);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_FacturasCompras_FacturaCompraId",
                        column: x => x.FacturaCompraId,
                        principalTable: "FacturasCompras",
                        principalColumn: "FacturaCompraId");
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_FacturasVentas_FacturaVentaId",
                        column: x => x.FacturaVentaId,
                        principalTable: "FacturasVentas",
                        principalColumn: "FacturaVentaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    IdMetodoPago = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaTransaccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    NombrePlataforma = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FacturaVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.IdMetodoPago);
                    table.ForeignKey(
                        name: "FK_MetodoPagos_FacturasVentas_FacturaVentaId",
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
                    { new Guid("1cb1de39-40fe-472b-bdb7-d37db36387fb"), 1, "Vendedor de Muebles" },
                    { new Guid("201b4cc5-5647-44b8-8664-08f49c8ebcf6"), 1, "Técnico de Acabados" },
                    { new Guid("24254ac3-4379-41ba-ab1d-d4c31ffc4855"), 1, "Diseñador de Muebles" },
                    { new Guid("5e74a02d-a99f-40e3-8c4c-a4c58a78ad04"), 1, "Carpintero" },
                    { new Guid("8d9b73ec-049b-483a-8d48-36e29c25021e"), 1, "Asistente de carpinteria" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Estado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0e371e3e-50c3-48c5-a583-db1016fb209c"), 1, "Camas" },
                    { new Guid("1ec8da08-607c-442c-82bd-2671992c080f"), 1, "Camarotes" },
                    { new Guid("21c0ab55-caf3-4636-882b-741d1fa2e352"), 1, "Armarios" },
                    { new Guid("2c9308f6-b13f-4714-b8c0-6b24d9b97389"), 1, "Sillas" },
                    { new Guid("3be4073a-8614-400e-bdce-2730059d9e76"), 1, "Escritorios" },
                    { new Guid("8a10a022-bcac-4d4a-9926-a2b4ba8bc993"), 1, "Mesas de Noche" },
                    { new Guid("c48f9793-637f-4f19-ac65-0cc5ecebcfd8"), 1, "Comedores" },
                    { new Guid("dd412b15-5220-43cd-90a8-228827cd4988"), 1, "Muebles" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellidos", "Estado", "FechaNacimiento", "Nombres", "Sexo" },
                values: new object[,]
                {
                    { new Guid("06e66a66-1840-4a55-abcf-475e8218963f"), "Hernández", 1, new DateTime(1983, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", "Masculino" },
                    { new Guid("1f03e9da-4f5a-4c01-a74b-5484a0622a88"), "Ramírez", 1, new DateTime(1987, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Alberto", "Masculino" },
                    { new Guid("41fff2b6-9886-40bc-ab38-d34cfaae3f96"), "González", 1, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana María", "Femenino" },
                    { new Guid("aad28fbf-f3e8-43b2-97d4-9eab3d59597a"), "López", 1, new DateTime(1999, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Femenino" },
                    { new Guid("da511896-b59c-4052-9103-6bf83a9f4b0a"), "Martínez", 1, new DateTime(2001, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "María José", "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "FacturasCompras",
                columns: new[] { "FacturaCompraId", "FechaExpedicion", "FechaGeneracion", "FechaVencimiento", "IdProveedor", "NFactura", "ProveedoresIdProveedor", "TotalBruto", "TotalIVA", "TotalPago", "TotalRefuete" },
                values: new object[,]
                {
                    { new Guid("5c5b2abf-5de1-49cb-98b8-6c13fddc7a6e"), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9abc8d3b-3bd1-49c3-84e2-35c59447b0f3"), 1, null, 100000f, 19000f, 139000f, 20000f },
                    { new Guid("6e922ba7-f823-4a3b-81ef-65a55a981c60"), new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e6d4c81-9958-44ff-bf39-838a4940c822"), 2, null, 150000f, 2850f, 182850f, 30000f }
                });

            migrationBuilder.InsertData(
                table: "FacturasVentas",
                columns: new[] { "FacturaVentaId", "FechaExpedicion", "FechaGeneracion", "FechaVencimiento", "IdUsuario", "NFactura", "TotalBruto", "TotalIVA", "TotalPago", "TotalRefuete", "UsuariosIdUsuario" },
                values: new object[,]
                {
                    { new Guid("a6cf357e-205e-45f4-be76-25c8e08aac16"), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1449f86e-3988-43c6-9210-252136156e7e"), 2, 120000f, 22800f, 157800f, 15000f, null },
                    { new Guid("ceda0177-4b48-4379-8907-b75c4f0aa10f"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0aac839-d3e4-4b5c-9b6e-dbf0303db2b2"), 1, 85000f, 16150f, 113150f, 12000f, null }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "IdProveedor", "Estado", "RazonSocial" },
                values: new object[,]
                {
                    { new Guid("0dd8f80d-4df6-4fe9-bb72-28c7f5561e7c"), 1, "Juguetes Vikingos" },
                    { new Guid("303504ff-9312-4d2b-9d52-8d16ef08eb69"), 1, "Marena" },
                    { new Guid("6e6d4c81-9958-44ff-bf39-838a4940c822"), 1, "Sol Dorado" },
                    { new Guid("7a1429e1-c547-4f00-a33a-d27d402bca3f"), 1, "Carlos Fernández, E.I.R" },
                    { new Guid("7f740088-b8c7-4094-90b3-9c6385e58597"), 2, "Grupo Fernández S.A" },
                    { new Guid("9abc8d3b-3bd1-49c3-84e2-35c59447b0f3"), 1, "Arcos Dorados, C.A" },
                    { new Guid("be2c0877-d46b-46e3-b793-cb5711f214c7"), 2, "Lima & Álvarez" },
                    { new Guid("d0a22af1-85b2-4ea6-9daa-d0e321c07964"), 1, "La Guitarra, S.A" },
                    { new Guid("e630fb8f-a34d-4b4d-9de1-6808fe6a6edf"), 1, "Chascomús, S.A" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Cargo", "Contrasena", "Estado", "FechaContrato", "FechaFin", "FechaNacimiento", "FechaRegistro", "Llave", "NumDocumento", "PrimApellido", "PrimNombre", "SegApellido", "SegNombre", "Sexo", "TipoDocumento", "TipoUsuario" },
                values: new object[,]
                {
                    { new Guid("1449f86e-3988-43c6-9210-252136156e7e"), "Administrador", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1019762822, "Marin", "Kevin", "Hoyos", "Alejandro", "Masculino", "C.C", 1 },
                    { new Guid("58d04fc7-e269-4e8b-aea4-3f6da3fea9bc"), "Asistente de carpinteria", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1013265449, "Velez", "Maria", "Wedderburn", "Fernanda", "Femenino", "C.C", 1 },
                    { new Guid("e0aac839-d3e4-4b5c-9b6e-dbf0303db2b2"), "Supervisor de Producción", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1025445665, "Ramirez", "David", "Martin", "Felipe", "Masculino", "C.C", 1 },
                    { new Guid("e5f2abb9-bcd0-422b-9e8c-9597bb21bec1"), "Encargado de almacén", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1016598778, "Rivera", "Lizeth", "Ruiz", "Valeria", "Femenino", "C.C", 1 },
                    { new Guid("fd1820f2-b0f0-47a0-af34-d6d465734f65"), "Carpintero", "", 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADSO2558108", 1013100300, "Sarmiento", "Miguel", "Mojica", "Angel", "Masculino", "C.C", 1 }
                });

            migrationBuilder.InsertData(
                table: "ContactoEmpleados",
                columns: new[] { "IdContactoEmpleado", "Direccion", "Email", "EmpleadoId", "FechaCreacion", "Telefono" },
                values: new object[,]
                {
                    { new Guid("07b892ef-0511-4cf4-b2c6-9cc4932418dd"), "Av. 7 de Septiembre #25-10", "ContactoE2@gmail.com", new Guid("1f03e9da-4f5a-4c01-a74b-5484a0622a88"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 315874920 },
                    { new Guid("319b841c-0573-416a-8754-fcd82aee04bc"), "Cra15B #13-52", "ContactoE1@gmail.com", new Guid("41fff2b6-9886-40bc-ab38-d34cfaae3f96"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 312546845 },
                    { new Guid("6215be00-b0a6-4df5-bf6f-481f8089c441"), "Cra 20 #8-45", "ContactoE5@gmail.com", new Guid("da511896-b59c-4052-9103-6bf83a9f4b0a"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 317654987 },
                    { new Guid("66a5c506-ca79-4323-9826-2719d047d961"), "Calle 24 #18-15", "ContactoE3@gmail.com", new Guid("aad28fbf-f3e8-43b2-97d4-9eab3d59597a"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 318657489 },
                    { new Guid("e385b218-e55b-4c17-ae51-58fa9343483e"), "Cra 10A #5-30", "ContactoE4@gmail.com", new Guid("06e66a66-1840-4a55-abcf-475e8218963f"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 314985632 }
                });

            migrationBuilder.InsertData(
                table: "ContactoProveedorConfigurations",
                columns: new[] { "IdContactoProveedor", "Email", "Estado", "FechaAlta", "FechaBaja", "IdProveedor", "NombreProv", "Telefono" },
                values: new object[,]
                {
                    { new Guid("11b72f91-f5a9-4e6a-8c48-624a0729941d"), "ContactP1@gmail.com", 1, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0a22af1-85b2-4ea6-9daa-d0e321c07964"), "Sam Raiden", 314526948 },
                    { new Guid("136ad92b-614d-41fa-90d7-1f0f4a6c6d6e"), "ContactP6@gmail.com", 1, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9abc8d3b-3bd1-49c3-84e2-35c59447b0f3"), "Juan Soto", 316547896 },
                    { new Guid("35ce9ea9-6aed-459e-9fde-c02b768ddbec"), "ContactP8@gmail.com", 2, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e630fb8f-a34d-4b4d-9de1-6808fe6a6edf"), "Luis Gutiérrez", 313258741 },
                    { new Guid("42dc025f-3e80-4768-930d-6ef208faac3e"), "ContactP2@gmail.com", 1, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e6d4c81-9958-44ff-bf39-838a4940c822"), "Laura Montoya", 310987654 },
                    { new Guid("6299ae61-9578-4898-a9d6-8697a84b9c84"), "ContactP3@gmail.com", 2, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("303504ff-9312-4d2b-9d52-8d16ef08eb69"), "Carlos Rivera", 317895623 },
                    { new Guid("6f562b34-cee6-4684-be79-4a3638de30f0"), "ContactP9@gmail.com", 1, new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f740088-b8c7-4094-90b3-9c6385e58597"), "Fernando López", 317896542 },
                    { new Guid("8a91ebd3-d855-4be0-af6d-5dd91d3a4811"), "ContactP7@gmail.com", 1, new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a1429e1-c547-4f00-a33a-d27d402bca3f"), "María Salas", 318564237 },
                    { new Guid("aaec0a58-444b-48bc-9291-6aaa50f27008"), "ContactP5@gmail.com", 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be2c0877-d46b-46e3-b793-cb5711f214c7"), "Ana Martínez", 319875634 },
                    { new Guid("d6e22b76-d99f-4376-9dee-b542ee7aa729"), "ContactP4@gmail.com", 1, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dd8f80d-4df6-4fe9-bb72-28c7f5561e7c"), "Elena Gómez", 312589764 }
                });

            migrationBuilder.InsertData(
                table: "ContactoUsuarioConfigurations",
                columns: new[] { "IdContactoCliente", "Barrio_Localidad", "Ciudad", "Direccion", "Email", "IdUsuario", "IndicativoCiudad", "NumeroTelefonico", "TipoTelefono" },
                values: new object[,]
                {
                    { new Guid("03b22d58-4a3d-4ab1-93d3-143686897a49"), "Usme", "Bogotá D.C.", "Cra 12C #53-08", "ContactoC1@gmail.com", new Guid("1449f86e-3988-43c6-9210-252136156e7e"), "601", 5614248, "Fijo" },
                    { new Guid("06dc8c36-d46e-4eb1-97d5-92355ba32b9f"), "San Fernando", "Cali", "Calle 24 #18-15", "ContactoC3@gmail.com", new Guid("58d04fc7-e269-4e8b-aea4-3f6da3fea9bc"), "571", 317895623, "Fijo" },
                    { new Guid("9d1a4bd6-e6eb-40bd-8333-a8745c90ae58"), "El Poblado", "Medellín", "Av. 7 de Septiembre #25-10", "ContactoC2@gmail.com", new Guid("e0aac839-d3e4-4b5c-9b6e-dbf0303db2b2"), "301", 315874920, "Celular" },
                    { new Guid("9f355a72-89f6-47c8-aaab-931e4d5d40a5"), "Granada", "Cali", "Cra 10A #5-30", "ContactoC4@gmail.com", new Guid("e5f2abb9-bcd0-422b-9e8c-9597bb21bec1"), "571", 318564237, "Celular" }
                });

            migrationBuilder.InsertData(
                table: "EmpleadoCargos",
                columns: new[] { "CargoId", "EmpleadoId", "FechaFin", "FechaInicio", "NumeroContrato" },
                values: new object[,]
                {
                    { new Guid("8d9b73ec-049b-483a-8d48-36e29c25021e"), new Guid("06e66a66-1840-4a55-abcf-475e8218963f"), new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { new Guid("1cb1de39-40fe-472b-bdb7-d37db36387fb"), new Guid("1f03e9da-4f5a-4c01-a74b-5484a0622a88"), new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("5e74a02d-a99f-40e3-8c4c-a4c58a78ad04"), new Guid("41fff2b6-9886-40bc-ab38-d34cfaae3f96"), new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("24254ac3-4379-41ba-ab1d-d4c31ffc4855"), new Guid("aad28fbf-f3e8-43b2-97d4-9eab3d59597a"), new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { new Guid("201b4cc5-5647-44b8-8664-08f49c8ebcf6"), new Guid("da511896-b59c-4052-9103-6bf83a9f4b0a"), new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "MetodoPagos",
                columns: new[] { "IdMetodoPago", "FacturaVentaId", "FechaTransaccion", "NombrePlataforma", "Tipo" },
                values: new object[,]
                {
                    { new Guid("37292a3a-0a69-41a5-a038-1795fa541cf9"), new Guid("a6cf357e-205e-45f4-be76-25c8e08aac16"), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daviplata", 2 },
                    { new Guid("5ef90d94-ca4a-49fe-ba78-e42e1c527606"), new Guid("ceda0177-4b48-4379-8907-b75c4f0aa10f"), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nequi", 2 }
                });

            migrationBuilder.InsertData(
                table: "Perdida",
                columns: new[] { "IdPerdida", "EmpleadoId", "Estado", "FechaPerdida", "Total" },
                values: new object[,]
                {
                    { new Guid("0a730c0e-c85f-4765-974c-cafc13ac4f57"), new Guid("da511896-b59c-4052-9103-6bf83a9f4b0a"), 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000f },
                    { new Guid("2dabb8f6-c2ef-4c37-8b6d-3f306241d100"), new Guid("aad28fbf-f3e8-43b2-97d4-9eab3d59597a"), 2, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 350000f },
                    { new Guid("42f9ca61-b335-421b-bc21-de794a40aed0"), new Guid("06e66a66-1840-4a55-abcf-475e8218963f"), 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 500000f },
                    { new Guid("556e454f-6ae9-4996-8344-95bd3c76ad36"), new Guid("1f03e9da-4f5a-4c01-a74b-5484a0622a88"), 2, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000f },
                    { new Guid("5ffa39ba-fd0e-4556-aebc-c62d3fcc0823"), new Guid("41fff2b6-9886-40bc-ab38-d34cfaae3f96"), 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 300000f }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Color", "Descripcion", "Estado", "IdCategoria", "Nombre", "OrigenMateriaPrima", "Precio", "Stock", "Tipo" },
                values: new object[,]
                {
                    { new Guid("30d27e06-251c-4911-819a-59a9a3966f78"), "Azul", "Camarote con temática de caricaturas", 1, new Guid("1ec8da08-607c-442c-82bd-2671992c080f"), "Camarote infantil", null, 450000f, 6, 2 },
                    { new Guid("3fa14058-d693-4ba9-8b10-f242599f40ea"), "Blanco", "Escritorio de diseño minimalista", 1, new Guid("3be4073a-8614-400e-bdce-2730059d9e76"), "Escritorio moderno", null, 350000f, 4, 1 },
                    { new Guid("5650a477-c720-4438-8dd4-44bc58e5cdda"), "Marrón", "Comedor de madera con capacidad para 6 personas", 1, new Guid("c48f9793-637f-4f19-ac65-0cc5ecebcfd8"), "Comedor extensible", null, 800000f, 2, 1 },
                    { new Guid("8b538521-a513-4f5a-b4e6-ae3c57912499"), "Café", "Armario espacioso con compartimentos", 1, new Guid("21c0ab55-caf3-4636-882b-741d1fa2e352"), "Armario de 4 puertas", null, 700000f, 1, 1 },
                    { new Guid("ce7dc2ea-5931-49a1-8946-9782a5843612"), "Gris", "Silla cómoda con soporte lumbar", 1, new Guid("2c9308f6-b13f-4714-b8c0-6b24d9b97389"), "Silla ergonómica", null, 250000f, 8, 2 },
                    { new Guid("dd6b62dc-f917-4379-9955-1c244ee78c4b"), "Negro", "Mesa de noche de estilo moderno", 1, new Guid("8a10a022-bcac-4d4a-9926-a2b4ba8bc993"), "Mesa de noche", null, 42500f, 5, 2 },
                    { new Guid("edf59c51-6384-422f-b941-ce879c82dcdc"), "Blanco", "Cama doble de madera", 1, new Guid("0e371e3e-50c3-48c5-a583-db1016fb209c"), "Cama doble", null, 60000f, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "DetalleFacturaCompra",
                columns: new[] { "DetalleacturaCompraId", "Cantidad", "FacturaCompraId", "IVA", "ProductoId", "ValorDescuento", "ValorUnitario" },
                values: new object[,]
                {
                    { new Guid("5aec0acf-8b05-40bb-a874-c244487b56af"), 4, new Guid("6e922ba7-f823-4a3b-81ef-65a55a981c60"), 0.3f, new Guid("30d27e06-251c-4911-819a-59a9a3966f78"), 0.05f, 500000f },
                    { new Guid("ab7dcddf-f549-4ae2-9c0d-e2237b831f76"), 2, new Guid("5c5b2abf-5de1-49cb-98b8-6c13fddc7a6e"), 0.3f, new Guid("ce7dc2ea-5931-49a1-8946-9782a5843612"), 0.05f, 250000f }
                });

            migrationBuilder.InsertData(
                table: "DetallesFacturaVentas",
                columns: new[] { "DetalleFacturaVentaID", "Cantidad", "FacturaCompraId", "FacturaVentaId", "IVA", "ProductoId", "ValorDescuento", "ValorUnitario" },
                values: new object[,]
                {
                    { new Guid("21980b54-0dd3-46b0-b77a-29eb80caa3c8"), 2, null, new Guid("a6cf357e-205e-45f4-be76-25c8e08aac16"), 1534f, new Guid("edf59c51-6384-422f-b941-ce879c82dcdc"), 0f, 60000f },
                    { new Guid("636e9434-f3aa-44d1-9ef0-8470d72a5bee"), 2, null, new Guid("ceda0177-4b48-4379-8907-b75c4f0aa10f"), 8075f, new Guid("dd6b62dc-f917-4379-9955-1c244ee78c4b"), 0f, 42500f }
                });

            migrationBuilder.InsertData(
                table: "HistoricosPrecios",
                columns: new[] { "IdHistoricoPrecios", "Estado", "FechaPrecioFinal", "FechaPrecioInicial", "PrecioVenta", "ProductoId" },
                values: new object[,]
                {
                    { new Guid("0db01178-1ee0-4b73-9e6c-fb51972517ec"), 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 38500f, new Guid("5650a477-c720-4438-8dd4-44bc58e5cdda") },
                    { new Guid("1c230e78-c12c-4bd8-a4b1-ca7fbc2d0549"), 1, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 55000f, new Guid("8b538521-a513-4f5a-b4e6-ae3c57912499") },
                    { new Guid("2cdc7499-0d1e-4413-9565-9d337d612b45"), 1, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 42500f, new Guid("edf59c51-6384-422f-b941-ce879c82dcdc") },
                    { new Guid("5d3d5dc3-fbe5-43ea-875b-3447e32c9e52"), 1, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000f, new Guid("ce7dc2ea-5931-49a1-8946-9782a5843612") },
                    { new Guid("6549ac0e-d34b-43b3-9fed-9847a2b17149"), 1, new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 70000f, new Guid("3fa14058-d693-4ba9-8b10-f242599f40ea") },
                    { new Guid("74604bcd-34f7-4bbc-90da-cd955c2a5117"), 1, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000f, new Guid("dd6b62dc-f917-4379-9955-1c244ee78c4b") },
                    { new Guid("a8cb8414-2308-4f71-a09a-6976dd23f396"), 1, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 42000f, new Guid("30d27e06-251c-4911-819a-59a9a3966f78") }
                });

            migrationBuilder.InsertData(
                table: "Perdida_Productos",
                columns: new[] { "IdPerdida", "ProductoId", "Cantidad", "Motivo", "PerdidaProductoId", "PrecioUnitario" },
                values: new object[,]
                {
                    { new Guid("0a730c0e-c85f-4765-974c-cafc13ac4f57"), new Guid("8b538521-a513-4f5a-b4e6-ae3c57912499"), 5, "Perdida", new Guid("00000000-0000-0000-0000-000000000000"), 100000f },
                    { new Guid("2dabb8f6-c2ef-4c37-8b6d-3f306241d100"), new Guid("edf59c51-6384-422f-b941-ce879c82dcdc"), 5, "Mal Estado", new Guid("00000000-0000-0000-0000-000000000000"), 350000f },
                    { new Guid("42f9ca61-b335-421b-bc21-de794a40aed0"), new Guid("30d27e06-251c-4911-819a-59a9a3966f78"), 5, "Daño", new Guid("00000000-0000-0000-0000-000000000000"), 500000f },
                    { new Guid("556e454f-6ae9-4996-8344-95bd3c76ad36"), new Guid("dd6b62dc-f917-4379-9955-1c244ee78c4b"), 5, "Roto", new Guid("00000000-0000-0000-0000-000000000000"), 200000f },
                    { new Guid("5ffa39ba-fd0e-4556-aebc-c62d3fcc0823"), new Guid("ce7dc2ea-5931-49a1-8946-9782a5843612"), 5, "Robo", new Guid("00000000-0000-0000-0000-000000000000"), 300000f }
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
                name: "IX_DetalleFacturaCompra_FacturaCompraId",
                table: "DetalleFacturaCompra",
                column: "FacturaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturaCompra_ProductoId",
                table: "DetalleFacturaCompra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_FacturaCompraId",
                table: "DetallesFacturaVentas",
                column: "FacturaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_FacturaVentaId",
                table: "DetallesFacturaVentas",
                column: "FacturaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_ProductoId",
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
                name: "IX_HistoricosPrecios_ProductoId",
                table: "HistoricosPrecios",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPagos_FacturaVentaId",
                table: "MetodoPagos",
                column: "FacturaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perdida_EmpleadoId",
                table: "Perdida",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perdida_Productos_ProductoId",
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
