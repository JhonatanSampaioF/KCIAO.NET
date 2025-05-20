using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCIAO.API.Migrations
{
    /// <inheritdoc />
    public partial class FixDoencaTableMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_repositorio_doenca",
                table: "tb_repositorio_doenca");

            migrationBuilder.RenameTable(
                name: "tb_repositorio_doenca",
                newName: "tb_doenca");

            migrationBuilder.AlterColumn<string>(
                name: "nm_cliente",
                table: "tb_cliente",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "nm_doenca",
                table: "tb_doenca",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_doenca",
                table: "tb_doenca",
                column: "id_doenca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_doenca",
                table: "tb_doenca");

            migrationBuilder.RenameTable(
                name: "tb_doenca",
                newName: "tb_repositorio_doenca");

            migrationBuilder.AlterColumn<string>(
                name: "nm_cliente",
                table: "tb_cliente",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nm_doenca",
                table: "tb_repositorio_doenca",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_repositorio_doenca",
                table: "tb_repositorio_doenca",
                column: "id_doenca");
        }
    }
}
