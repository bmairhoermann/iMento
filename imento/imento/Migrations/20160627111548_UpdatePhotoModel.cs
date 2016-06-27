using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace imento.Migrations
{
    public partial class UpdatePhotoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFavourite",
                table: "Photos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFavourite",
                table: "Photos");
        }
    }
}
