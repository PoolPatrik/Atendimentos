using Microsoft.EntityFrameworkCore.Migrations;

namespace Atendimentos.Migrations
{
    public partial class AjustandoDominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Revendedor_RevendedorId",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Sistema_SistemaId",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId",
                table: "Atendimento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sistema",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Revendedor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Atendimento",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SistemaId",
                table: "Atendimento",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RevendedorId",
                table: "Atendimento",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrição = table.Column<string>(nullable: false),
                    AtendimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Atendimento_AtendimentoId",
                        column: x => x.AtendimentoId,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_AtendimentoId",
                table: "Comentario",
                column: "AtendimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Revendedor_RevendedorId",
                table: "Atendimento",
                column: "RevendedorId",
                principalTable: "Revendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Sistema_SistemaId",
                table: "Atendimento",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId",
                table: "Atendimento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Revendedor_RevendedorId",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Sistema_SistemaId",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId",
                table: "Atendimento");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sistema",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Revendedor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Atendimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SistemaId",
                table: "Atendimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RevendedorId",
                table: "Atendimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Revendedor_RevendedorId",
                table: "Atendimento",
                column: "RevendedorId",
                principalTable: "Revendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Sistema_SistemaId",
                table: "Atendimento",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId",
                table: "Atendimento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
