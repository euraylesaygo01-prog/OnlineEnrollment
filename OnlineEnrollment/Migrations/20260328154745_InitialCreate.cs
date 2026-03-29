using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Slots = table.Column<int>(type: "int", nullable: false),
                    EnrolledCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrolledAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "Id", "Email", "FullName", "Password" },
                values: new object[] { 1, "admin@onlineenrollment.com", "Administrator", "admin123" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Department", "EnrolledCount", "IsActive", "Name", "Schedule", "Slots", "Units" },
                values: new object[,]
                {
                    { 1, "BSA", "Business", 0, true, "BS Accountancy", "MWF 7:30-9:00", 40, 24 },
                    { 2, "BSBA", "Business", 0, true, "BS Business Administration", "TTH 7:30-9:00", 40, 24 },
                    { 3, "BSE", "Business", 0, true, "BS Entrepreneurship", "MWF 9:00-10:30", 40, 24 },
                    { 4, "BSME", "Business", 0, true, "BS Management Engineering", "TTH 9:00-10:30", 40, 24 },
                    { 5, "BSCS", "STEM", 0, true, "BS Computer Science", "MWF 7:30-9:00", 40, 24 },
                    { 6, "BSIT", "STEM", 0, true, "BS Information Technology", "TTH 7:30-9:00", 40, 24 },
                    { 7, "BSCE", "STEM", 0, true, "BS Civil Engineering", "MWF 9:00-10:30", 40, 24 },
                    { 8, "BSEE", "STEM", 0, true, "BS Electrical Engineering", "TTH 9:00-10:30", 40, 24 },
                    { 9, "BSBIO", "STEM", 0, true, "BS Biology", "MWF 10:30-12:00", 40, 24 },
                    { 10, "BSN", "STEM", 0, true, "BS Nursing", "TTH 10:30-12:00", 40, 24 },
                    { 11, "BSPSY", "Social Sciences", 0, true, "BS Psychology", "MWF 7:30-9:00", 40, 24 },
                    { 12, "ABCOM", "Social Sciences", 0, true, "AB Communication", "TTH 7:30-9:00", 40, 24 },
                    { 13, "ABPOLSCI", "Social Sciences", 0, true, "AB Political Science", "MWF 9:00-10:30", 40, 24 },
                    { 14, "ABFA", "Social Sciences", 0, true, "AB Fine Arts", "TTH 9:00-10:30", 40, 24 },
                    { 15, "BSED", "Education", 0, true, "BS Secondary Education", "MWF 7:30-9:00", 40, 24 },
                    { 16, "BEED", "Education", 0, true, "BS Elementary Education", "TTH 7:30-9:00", 40, 24 },
                    { 17, "BSARCH", "Education", 0, true, "BS Architecture", "MWF 9:00-10:30", 40, 24 },
                    { 18, "MMA", "Education", 0, true, "Multimedia Arts", "TTH 9:00-10:30", 40, 24 },
                    { 19, "HRM", "General Education", 0, true, "Hotel & Restaurant Management", "MWF 7:30-9:00", 40, 24 },
                    { 20, "BSLM", "General Education", 0, true, "BS Legal Management", "TTH 7:30-9:00", 40, 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
