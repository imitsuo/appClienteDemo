using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace clientprj.Migrations
{
    public partial class Cli_campos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Clients",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Clients");
        }
    }
}
