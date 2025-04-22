using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorPedidos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alowOrderItemWithoutOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId",
                table: "ItensPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItensPedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId",
                table: "ItensPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItensPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
