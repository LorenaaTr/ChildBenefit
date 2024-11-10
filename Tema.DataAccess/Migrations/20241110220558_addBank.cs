using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tema.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addBank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AkronimiBankes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AkronimiBankes", "BankName" },
                values: new object[,]
                {
                    { 1, "RBKO", "Raiffeisen Bank" },
                    { 2, "PCBK", "ProCredit Bank" },
                    { 3, "NLB", "NLB Bank" },
                    { 4, "TEBK", "TEB Bank" },
                    { 5, "BPB", "BPB Bank" },
                    { 6, "BEK", "Banka Ekonomike" },
                    { 7, "ZIRAAT", "Ziraat Bank" },
                    { 8, "KB", "Komercijalna Banka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
