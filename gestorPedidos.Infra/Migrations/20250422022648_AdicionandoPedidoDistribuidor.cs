using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorPedidos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoPedidoDistribuidor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoDistribuidorId",
                table: "ItensPedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PedidoDistribuidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevendaId = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sucesso = table.Column<bool>(type: "bit", nullable: false),
                    Retorno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDistribuidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoDistribuidores_Revendas_RevendaId",
                        column: x => x.RevendaId,
                        principalTable: "Revendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoDistribuidorId",
                table: "ItensPedidos",
                column: "PedidoDistribuidorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDistribuidores_RevendaId",
                table: "PedidoDistribuidores",
                column: "RevendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_PedidoDistribuidores_PedidoDistribuidorId",
                table: "ItensPedidos",
                column: "PedidoDistribuidorId",
                principalTable: "PedidoDistribuidores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_PedidoDistribuidores_PedidoDistribuidorId",
                table: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "PedidoDistribuidores");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_PedidoDistribuidorId",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "PedidoDistribuidorId",
                table: "ItensPedidos");
        }
    }
}
