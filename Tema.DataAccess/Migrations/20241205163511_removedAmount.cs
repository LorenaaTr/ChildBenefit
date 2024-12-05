using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tema.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removedAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Parents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
