using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace clientprj.Migrations
{
    public partial class documento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Clients",
                type: "nvarchar(20)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Clients");
        }
    }
}
