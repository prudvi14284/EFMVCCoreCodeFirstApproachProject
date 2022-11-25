using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFMVC.Migrations
{
    /// <inheritdoc />
    public partial class ManyToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.AddColumn<int>(
                name: "TeacherSubjectsSubjectId",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_TeacherSubjectsSubjectId",
                table: "Teacher",
                column: "TeacherSubjectsSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Subjects_TeacherSubjectsSubjectId",
                table: "Teacher",
                column: "TeacherSubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Subjects_TeacherSubjectsSubjectId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_TeacherSubjectsSubjectId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "TeacherSubjectsSubjectId",
                table: "Teacher");

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectTeachersTeacherId = table.Column<int>(type: "int", nullable: false),
                    TeacherSubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectTeachersTeacherId, x.TeacherSubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_TeacherSubjectsSubjectId",
                        column: x => x.TeacherSubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teacher_SubjectTeachersTeacherId",
                        column: x => x.SubjectTeachersTeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherSubjectsSubjectId",
                table: "SubjectTeacher",
                column: "TeacherSubjectsSubjectId");
        }
    }
}
