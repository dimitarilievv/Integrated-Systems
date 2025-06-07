using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesApplication.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentOnCourses_AspNetUsers_StudentId1",
                table: "StudentOnCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentOnCourses_StudentId1",
                table: "StudentOnCourses");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentOnCourses");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOnCourses_StudentId",
                table: "StudentOnCourses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOnCourses_AspNetUsers_StudentId",
                table: "StudentOnCourses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentOnCourses_AspNetUsers_StudentId",
                table: "StudentOnCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentOnCourses_StudentId",
                table: "StudentOnCourses");

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "StudentOnCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentOnCourses_StudentId1",
                table: "StudentOnCourses",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOnCourses_AspNetUsers_StudentId1",
                table: "StudentOnCourses",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
