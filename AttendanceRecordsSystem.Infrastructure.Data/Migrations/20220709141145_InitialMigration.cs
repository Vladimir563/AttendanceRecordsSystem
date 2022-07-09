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
                    Name = table.Column<string>(nullable: true)
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
                    StudentsGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StudentsGroups_StudentsGroupId",
                        column: x => x.StudentsGroupId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'13', '1', '', '', 'False', '1'")
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
                    { 1, "Ирина", "Сахарова", "Петровна" },
                    { 2, "Иван", "Лопатин", "Денисович" }
                });

            migrationBuilder.InsertData(
                table: "StudentsGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "А1" },
                    { 2, "А2" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "StudentsGroupId" },
                values: new object[,]
                {
                    { 1, "Ольга", "Ласкина", 1 },
                    { 2, "Тамара", "Комарова", 1 },
                    { 3, "Владимир", "Семёнов", 2 },
                    { 4, "Игорь", "Онисьев", 2 }
                });

            migrationBuilder.InsertData(
                table: "Lections",
                columns: new[] { "Id", "Date", "LectorId", "Mark", "StudentId", "Tittle" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 1, "Математика" },
                    { 4, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 1, "Физика" },
                    { 8, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1, "Философия" },
                    { 5, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 2, "Физика" },
                    { 10, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 2, "Литература" },
                    { 2, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, "Математика" },
                    { 6, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, "Физика" },
                    { 11, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 3, "Литература" },
                    { 3, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 4, "Математика" },
                    { 7, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, "Физика" },
                    { 9, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 4, "Философия" },
                    { 12, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 4, "Литература" }
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
                name: "IX_Students_StudentsGroupId",
                table: "Students",
                column: "StudentsGroupId");
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
