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
                name: "tb_consulta",
                columns: table => new
                {
                    id_consulta = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    profissional = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    local_consulta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    horario_consulta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consulta", x => x.id_consulta);
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
                    dt_evento = table.Column<string>(type: "NVARCHAR2(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_evento", x => x.id_evento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_consulta");

            migrationBuilder.DropTable(
                name: "tb_doenca");

            migrationBuilder.DropTable(
                name: "tb_evento");
        }
    }
}
