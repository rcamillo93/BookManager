using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamaColumnsAndRestrictionUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_IdLivro",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_IdUsuario",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Loans",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "IdLivro",
                table: "Loans",
                newName: "IdBook");

            migrationBuilder.RenameColumn(
                name: "Devolvido",
                table: "Loans",
                newName: "Returned");

            migrationBuilder.RenameColumn(
                name: "DataPrevista",
                table: "Loans",
                newName: "ExpectedDate");

            migrationBuilder.RenameColumn(
                name: "DataEmprestimo",
                table: "Loans",
                newName: "LoanDate");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_IdUsuario",
                table: "Loans",
                newName: "IX_Loans_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_IdLivro",
                table: "Loans",
                newName: "IX_Loans_IdBook");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "Books",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "Books",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "AnoPublicacao",
                table: "Books",
                newName: "YearPublication");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRestriction",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRestrictions",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_IdBook",
                table: "Loans",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_IdUser",
                table: "Loans",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_IdBook",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_IdUser",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateRestriction",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumberOfRestrictions",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Returned",
                table: "Loans",
                newName: "Devolvido");

            migrationBuilder.RenameColumn(
                name: "LoanDate",
                table: "Loans",
                newName: "DataEmprestimo");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Loans",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "Loans",
                newName: "IdLivro");

            migrationBuilder.RenameColumn(
                name: "ExpectedDate",
                table: "Loans",
                newName: "DataPrevista");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_IdUser",
                table: "Loans",
                newName: "IX_Loans_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_IdBook",
                table: "Loans",
                newName: "IX_Loans_IdLivro");

            migrationBuilder.RenameColumn(
                name: "YearPublication",
                table: "Books",
                newName: "AnoPublicacao");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Books",
                newName: "Disponivel");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "Autor");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_IdLivro",
                table: "Loans",
                column: "IdLivro",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_IdUsuario",
                table: "Loans",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
