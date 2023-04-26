﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedEl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVehiclesBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Vehicles",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Vehicles");
        }
    }
}
