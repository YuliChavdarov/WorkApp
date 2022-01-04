﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkApp.Data.Migrations
{
    public partial class AddProfileCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProfileCreated",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileCreated",
                table: "AspNetUsers");
        }
    }
}
