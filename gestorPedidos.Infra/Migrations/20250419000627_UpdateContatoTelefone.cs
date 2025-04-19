using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorPedidos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContatoTelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Revendas_RevendaId",
                table: "Telefones");

            migrationBuilder.RenameColumn(
                name: "RevendaId",
                table: "Telefones",
                newName: "ContatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_RevendaId",
                table: "Telefones",
                newName: "IX_Telefones_ContatoId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Telefones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Ddd",
                table: "Telefones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Contatos_ContatoId",
                table: "Telefones",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Contatos_ContatoId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "Ddd",
                table: "Telefones");

            migrationBuilder.RenameColumn(
                name: "ContatoId",
                table: "Telefones",
                newName: "RevendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_ContatoId",
                table: "Telefones",
                newName: "IX_Telefones_RevendaId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Telefones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Revendas_RevendaId",
                table: "Telefones",
                column: "RevendaId",
                principalTable: "Revendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
