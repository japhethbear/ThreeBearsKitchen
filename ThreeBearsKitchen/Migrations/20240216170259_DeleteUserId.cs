﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreeBearsKitchen.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
