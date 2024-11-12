using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tema.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addStatusToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
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
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[,]
                {
                    { 1, "Aktiv", "Active", "Aktivan" },
                    { 2, "Pasiv", "Passive", "Pasivni" },
                    { 3, "Nderprere", "Suspended", "Suspendovan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
