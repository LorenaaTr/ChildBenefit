﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tema.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderTabelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SrDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
