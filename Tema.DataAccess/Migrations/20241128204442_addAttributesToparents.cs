using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tema.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAttributesToparents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Relations_RelationId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Statuses_StatusId",
                table: "Children");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "Parents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlDescription", "EnDescription" },
                values: new object[] { "Prind", "Parent" });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "Id", "AlDescription", "EnDescription", "SrDescription" },
                values: new object[] { 3, "Kujdestar", "Custodian", "Roditejl" });

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StatusId",
                table: "Parents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentId",
                table: "Children",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "IdParent",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Relations_RelationId",
                table: "Children",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Statuses_StatusId",
                table: "Children",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Statuses_StatusId",
                table: "Parents",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Relations_RelationId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Statuses_StatusId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Statuses_StatusId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_StatusId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Children_ParentId",
                table: "Children");

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Children");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlDescription", "EnDescription" },
                values: new object[] { "Prind/Kujdestar", "Parent/ Custodian" });

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Relations_RelationId",
                table: "Children",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Statuses_StatusId",
                table: "Children",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
