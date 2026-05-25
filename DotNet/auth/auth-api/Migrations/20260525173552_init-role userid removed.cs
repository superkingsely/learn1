using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auth_api.Migrations
{
    /// <inheritdoc />
    public partial class initroleuseridremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
