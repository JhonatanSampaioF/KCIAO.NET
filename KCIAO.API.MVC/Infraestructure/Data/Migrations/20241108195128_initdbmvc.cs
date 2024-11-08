using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCIAO.API.MVC.Migrations
{
    /// <inheritdoc />
    public partial class initdbmvc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    id_cliente = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    nm_cliente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_doenca",
                columns: table => new
                {
                    id_doenca = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    nm_doenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_doenca", x => x.id_doenca);
                });

            migrationBuilder.CreateTable(
                name: "tb_evento",
                columns: table => new
                {
                    id_evento = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    tipo_evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    desc_evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    dt_evento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    fk_cliente = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_evento", x => x.id_evento);
                    table.ForeignKey(
                        name: "FK_tb_evento_tb_cliente_fk_cliente",
                        column: x => x.fk_cliente,
                        principalTable: "tb_cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cliente_doenca",
                columns: table => new
                {
                    fk_cliente = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    fk_doenca = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente_doenca", x => new { x.fk_cliente, x.fk_doenca });
                    table.ForeignKey(
                        name: "FK_tb_cliente_doenca_tb_cliente_fk_cliente",
                        column: x => x.fk_cliente,
                        principalTable: "tb_cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cliente_doenca_tb_doenca_fk_doenca",
                        column: x => x.fk_doenca,
                        principalTable: "tb_doenca",
                        principalColumn: "id_doenca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_consulta",
                columns: table => new
                {
                    id_consulta = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    profissional = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    local_consulta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    horario_consulta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    fk_evento = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consulta", x => x.id_consulta);
                    table.ForeignKey(
                        name: "FK_tb_consulta_tb_evento_fk_evento",
                        column: x => x.fk_evento,
                        principalTable: "tb_evento",
                        principalColumn: "id_evento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cliente_doenca_fk_doenca",
                table: "tb_cliente_doenca",
                column: "fk_doenca");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_fk_evento",
                table: "tb_consulta",
                column: "fk_evento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_evento_fk_cliente",
                table: "tb_evento",
                column: "fk_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cliente_doenca");

            migrationBuilder.DropTable(
                name: "tb_consulta");

            migrationBuilder.DropTable(
                name: "tb_doenca");

            migrationBuilder.DropTable(
                name: "tb_evento");

            migrationBuilder.DropTable(
                name: "tb_cliente");
        }
    }
}
