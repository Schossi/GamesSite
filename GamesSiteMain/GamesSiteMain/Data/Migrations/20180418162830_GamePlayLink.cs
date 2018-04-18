using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GamesSiteMain.Data.Migrations
{
    public partial class GamePlayLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayLink",
                table: "Games",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayLink",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
