using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tema.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[] { 1, "Kosova", "Kosovo", "Kosovo" });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[,]
                {
                    { 1, "Nene e nje ose dy femijeve", "Mother of one or two children", "Majka jednog ili dvoje dece" },
                    { 2, "Nene e tre apo me shume femijeve", "Mother of three or more children", "Majka troje ili više dece" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[,]
                {
                    { 1, "Gjuhe Shqipe", "Albanian", "Albanski" },
                    { 2, "Gjuhe Angleze", "English", "Engleski" },
                    { 3, "Gjuhe Serbe", "Serbian", "Srpski" },
                    { 4, "Gjuhe Rome", "Rome", "Rome" },
                    { 5, "Gjuhe Boshnjake", "Bosnian", "Bosanski" },
                    { 6, "Gjuhe Turke", "Turkish", "Turski" },
                    { 7, "Te tjera", "Others", "Drugi" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatus",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[,]
                {
                    { 1, "I/E martuar", "Married", "Ozenjen" },
                    { 2, "I/E divorcuar", "Divorced", "Razveden" },
                    { 3, "I/E ve", "Widow", "Udovica" },
                    { 4, "Beqare", "Single", "Samac" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[,]
                {
                    { 1, "Shqiptare", "Albanian", "Albanski" },
                    { 2, "Turk", "Turkish", "Albanski" },
                    { 3, "Ashkali", "Ashkali", "Ashkali" },
                    { 4, "Rom", "Rom", "Rom" },
                    { 5, "Egjiptian", "Egjiptian", "Egjiptian" },
                    { 6, "Boshnjak", "Boshnjak", "Boshnjak" },
                    { 7, "Goran", "Goran", "Goran" },
                    { 8, "Serb", "Serb", "Serb" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[,]
                {
                    { 1, "Prishtina", "Pristina", "Pristina" },
                    { 2, "Mitrovica", "Mitrovica", "Mitrovica" },
                    { 3, "Peja", "Peja", "Peja" },
                    { 4, "Prizren", "Prizren", "Prizren" },
                    { 5, "Ferizaj", "Ferizaj", "Ferizaj" },
                    { 6, "Gjilan", "Gjilan", "Gjilan" },
                    { 7, "Gjakova", "Gjakova", "Gjakova" }
                });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[,]
                {
                    { 1, "Femije", "Child", "Deco" },
                    { 2, "Prind/Kujdestar", "Parent/ Custodian", "Roditejl" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
