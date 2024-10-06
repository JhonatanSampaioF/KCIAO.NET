using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCIAO.API.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    id_cliente = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    nm_cliente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_repositorio_doenca",
                columns: table => new
                {
                    id_doenca = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    nm_doenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_repositorio_doenca", x => x.id_doenca);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_repositorio_doenca");
        }
    }
}
