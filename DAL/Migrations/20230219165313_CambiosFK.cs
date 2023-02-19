using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CambiosFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dwh_torrecontrol");

            migrationBuilder.CreateTable(
                name: "tdc_cat_estados_devolucion_pedido",
                schema: "dwh_torrecontrol",
                columns: table => new
                {
                    codestadodevolucion = table.Column<string>(name: "cod_estado_devolucion", type: "character varying", nullable: false),
                    mduuid = table.Column<string>(name: "md_uuid", type: "character varying", nullable: false),
                    mddate = table.Column<DateTime>(name: "md_date", type: "timestamp without time zone", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    desestadodevolucion = table.Column<string>(name: "des_estado_devolucion", type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tdc_cat_estados_devolucion_pedido_pkey", x => x.codestadodevolucion);
                });

            migrationBuilder.CreateTable(
                name: "tdc_cat_estados_envio_pedido",
                schema: "dwh_torrecontrol",
                columns: table => new
                {
                    codestadoenvio = table.Column<string>(name: "cod_estado_envio", type: "character varying", nullable: false),
                    mduuid = table.Column<string>(name: "md_uuid", type: "character varying", nullable: false),
                    mddate = table.Column<DateTime>(name: "md_date", type: "timestamp without time zone", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    desestadoenvio = table.Column<string>(name: "des_estado_envio", type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tdc_cat_estados_envio_pedido_pkey", x => x.codestadoenvio);
                });

            migrationBuilder.CreateTable(
                name: "tdc_cat_estados_pago_pedido",
                schema: "dwh_torrecontrol",
                columns: table => new
                {
                    codestadopago = table.Column<string>(name: "cod_estado_pago", type: "character varying", nullable: false),
                    mduuid = table.Column<string>(name: "md_uuid", type: "character varying", nullable: false),
                    mddate = table.Column<DateTime>(name: "md_date", type: "timestamp without time zone", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    desestadopago = table.Column<string>(name: "des_estado_pago", type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tdc_cat_estados_pago_pedido_pkey", x => x.codestadopago);
                });

            migrationBuilder.CreateTable(
                name: "tdc_cat_lineas_distribucion",
                schema: "dwh_torrecontrol",
                columns: table => new
                {
                    codlinea = table.Column<string>(name: "cod_linea", type: "character varying", nullable: false),
                    mduuid = table.Column<string>(name: "md_uuid", type: "character varying", nullable: false),
                    mddate = table.Column<DateTime>(name: "md_date", type: "timestamp without time zone", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    codprovincia = table.Column<string>(name: "cod_provincia", type: "character varying", nullable: false),
                    codmunicipio = table.Column<string>(name: "cod_municipio", type: "character varying", nullable: false),
                    codbarrio = table.Column<string>(name: "cod_barrio", type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tdc_cat_lineas_distribucion_pkey", x => x.codlinea);
                });

            migrationBuilder.CreateTable(
                name: "Tdc_tch_estado_pedidos",
                schema: "dwh_torrecontrol",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mduuid = table.Column<string>(name: "Md_uuid", type: "text", nullable: false),
                    Mddate = table.Column<DateTime>(name: "Md_date", type: "timestamp without time zone", nullable: false),
                    Codestadoenvio = table.Column<string>(name: "Cod_estado_envio", type: "character varying", nullable: true),
                    Codestadopago = table.Column<string>(name: "Cod_estado_pago", type: "character varying", nullable: true),
                    Codestadodevolucion = table.Column<string>(name: "Cod_estado_devolucion", type: "character varying", nullable: true),
                    Codpedido = table.Column<string>(name: "Cod_pedido", type: "text", nullable: false),
                    Codlinea = table.Column<string>(name: "Cod_linea", type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tdc_tch_estado_pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tdc_tch_estado_pedidos_Tdc_cat_estados_devolucion_pedido_Co~",
                        column: x => x.Codestadodevolucion,
                        principalSchema: "dwh_torrecontrol",
                        principalTable: "tdc_cat_estados_devolucion_pedido",
                        principalColumn: "cod_estado_devolucion");
                    table.ForeignKey(
                        name: "FK_Tdc_tch_estado_pedidos_Tdc_cat_estados_envio_pedido_Cod_est~",
                        column: x => x.Codestadoenvio,
                        principalSchema: "dwh_torrecontrol",
                        principalTable: "tdc_cat_estados_envio_pedido",
                        principalColumn: "cod_estado_envio");
                    table.ForeignKey(
                        name: "FK_Tdc_tch_estado_pedidos_Tdc_cat_estados_pago_pedido_Cod_esta~",
                        column: x => x.Codestadopago,
                        principalSchema: "dwh_torrecontrol",
                        principalTable: "tdc_cat_estados_pago_pedido",
                        principalColumn: "cod_estado_pago");
                    table.ForeignKey(
                        name: "FK_Tdc_tch_estado_pedidos_tdc_cat_lineas_distribucion_Cod_linea",
                        column: x => x.Codlinea,
                        principalSchema: "dwh_torrecontrol",
                        principalTable: "tdc_cat_lineas_distribucion",
                        principalColumn: "cod_linea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tdc_tch_estado_pedidos_Cod_estado_devolucion",
                schema: "dwh_torrecontrol",
                table: "Tdc_tch_estado_pedidos",
                column: "Cod_estado_devolucion");

            migrationBuilder.CreateIndex(
                name: "IX_Tdc_tch_estado_pedidos_Cod_estado_envio",
                schema: "dwh_torrecontrol",
                table: "Tdc_tch_estado_pedidos",
                column: "Cod_estado_envio");

            migrationBuilder.CreateIndex(
                name: "IX_Tdc_tch_estado_pedidos_Cod_estado_pago",
                schema: "dwh_torrecontrol",
                table: "Tdc_tch_estado_pedidos",
                column: "Cod_estado_pago");

            migrationBuilder.CreateIndex(
                name: "IX_Tdc_tch_estado_pedidos_Cod_linea",
                schema: "dwh_torrecontrol",
                table: "Tdc_tch_estado_pedidos",
                column: "Cod_linea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tdc_tch_estado_pedidos",
                schema: "dwh_torrecontrol");

            migrationBuilder.DropTable(
                name: "tdc_cat_estados_devolucion_pedido",
                schema: "dwh_torrecontrol");

            migrationBuilder.DropTable(
                name: "tdc_cat_estados_envio_pedido",
                schema: "dwh_torrecontrol");

            migrationBuilder.DropTable(
                name: "tdc_cat_estados_pago_pedido",
                schema: "dwh_torrecontrol");

            migrationBuilder.DropTable(
                name: "tdc_cat_lineas_distribucion",
                schema: "dwh_torrecontrol");
        }
    }
}
