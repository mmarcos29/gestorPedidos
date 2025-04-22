using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorPedidos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PermitindoNullEmPedidoDistribuidor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Retorno",
                table: "PedidoDistribuidores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Retorno",
                table: "PedidoDistribuidores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
