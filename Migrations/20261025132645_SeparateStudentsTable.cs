using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorManagment.API.Migrations
{
    /// <inheritdoc />
    public partial class SeparateStudentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Users_StudentID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_StudentID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_StudentProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Contacts",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Target = table.Column<string>(type: "text", nullable: false),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    Contacts = table.Column<string>(type: "text", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Students_StudentID",
                table: "Lessons",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Students_StudentID",
                table: "Payments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_StudentProfileId",
                table: "Users",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Students_StudentID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Students_StudentID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_StudentProfileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacts",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Users_StudentID",
                table: "Lessons",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_StudentID",
                table: "Payments",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_StudentProfileId",
                table: "Users",
                column: "StudentProfileId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
