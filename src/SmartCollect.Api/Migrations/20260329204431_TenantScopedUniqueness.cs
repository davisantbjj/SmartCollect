using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCollect.Api.Migrations
{
    /// <inheritdoc />
    public partial class TenantScopedUniqueness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TenantId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Titulos_CodigoUnico",
                table: "Titulos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Cnpj",
                table: "Clientes");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Titulos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Clientes",
                type: "uuid",
                nullable: true);

            migrationBuilder.Sql(@"
                UPDATE ""Clientes"" c
                SET ""TenantId"" = u.""TenantId""
                FROM ""Usuarios"" u
                WHERE c.""UsuarioId"" = u.""Id"";
            ");

            migrationBuilder.Sql(@"
                UPDATE ""Titulos"" t
                SET ""TenantId"" = c.""TenantId""
                FROM ""Clientes"" c
                WHERE t.""ClienteId"" = c.""Id"";
            ");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (SELECT 1 FROM ""Clientes"" WHERE ""TenantId"" IS NULL) THEN
                        RAISE EXCEPTION 'Migration aborted: some Clientes rows still have NULL TenantId';
                    END IF;

                    IF EXISTS (SELECT 1 FROM ""Titulos"" WHERE ""TenantId"" IS NULL) THEN
                        RAISE EXCEPTION 'Migration aborted: some Titulos rows still have NULL TenantId';
                    END IF;
                END$$;
            ");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "Titulos",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "Clientes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TenantId_Email",
                table: "Usuarios",
                columns: new[] { "TenantId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_TenantId_CodigoUnico",
                table: "Titulos",
                columns: new[] { "TenantId", "CodigoUnico" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TenantId_Cnpj",
                table: "Clientes",
                columns: new[] { "TenantId", "Cnpj" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Tenancies_TenantId",
                table: "Clientes",
                column: "TenantId",
                principalTable: "Tenancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titulos_Tenancies_TenantId",
                table: "Titulos",
                column: "TenantId",
                principalTable: "Tenancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Tenancies_TenantId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Titulos_Tenancies_TenantId",
                table: "Titulos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TenantId_Email",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Titulos_TenantId_CodigoUnico",
                table: "Titulos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_TenantId_Cnpj",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TenantId",
                table: "Usuarios",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_CodigoUnico",
                table: "Titulos",
                column: "CodigoUnico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cnpj",
                table: "Clientes",
                column: "Cnpj",
                unique: true);
        }
    }
}
