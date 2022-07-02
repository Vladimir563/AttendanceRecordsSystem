using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AttendanceRecordsSystem.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'5', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StudentsGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'17', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Tittle = table.Column<string>(nullable: true),
                    Mark = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    LectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lections_Lectors_LectorId",
                        column: x => x.LectorId,
                        principalTable: "Lectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lections_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lectors",
                columns: new[] { "Id", "FirstName", "LastName", "Patronymic" },
                values: new object[,]
                {
                    { 1, "Irina", "Sakharova", "Petrovna" },
                    { 2, "Ivan", "Lopatin", "Denisovich" }
                });

            migrationBuilder.InsertData(
                table: "StudentsGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[,]
                {
                    { 1, "A1" },
                    { 2, "A2" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 1, "Olga", 1, "Laskina" },
                    { 2, "Tamara", 1, "Komarova" },
                    { 3, "Vladimir", 2, "Semenov" },
                    { 4, "Igor", 2, "Onisiev" }
                });

            migrationBuilder.InsertData(
                table: "Lections",
                columns: new[] { "Id", "Date", "LectorId", "Mark", "StudentId", "Tittle" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 1, "Math" },
                    { 5, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 1, "Physics" },
                    { 9, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1, "Philosophy" },
                    { 13, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1, "Literature" },
                    { 2, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, "Math" },
                    { 6, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 2, "Physics" },
                    { 10, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 2, "Philosophy" },
                    { 14, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 2, "Literature" },
                    { 3, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, "Math" },
                    { 7, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, "Physics" },
                    { 11, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 3, "Philosophy" },
                    { 15, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 3, "Literature" },
                    { 4, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 4, "Math" },
                    { 8, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, "Physics" },
                    { 12, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 4, "Philosophy" },
                    { 16, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 4, "Literature" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lections_LectorId",
                table: "Lections",
                column: "LectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lections_StudentId",
                table: "Lections",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lections");

            migrationBuilder.DropTable(
                name: "Lectors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentsGroups");
        }
    }
}
