using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace clientprj.Migrations
{
    public partial class removeCpfCnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clients",
                nullable: true);
        }
    }
}
