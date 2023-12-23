using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewAppProject.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewProfessorTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewProfessorTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReviewsCount = table.Column<int>(type: "int", nullable: false),
                    Reputation = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<double>(type: "float", nullable: false),
                    Opportunities = table.Column<double>(type: "float", nullable: false),
                    Facilities = table.Column<double>(type: "float", nullable: false),
                    Internet = table.Column<double>(type: "float", nullable: false),
                    Food = table.Column<double>(type: "float", nullable: false),
                    Clubs = table.Column<double>(type: "float", nullable: false),
                    Social = table.Column<double>(type: "float", nullable: false),
                    Happiness = table.Column<double>(type: "float", nullable: false),
                    Safety = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoursesCount = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WouldTakeAgainPercentage = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DifficultyPercentage = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    AverageRating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ReviewsCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CoursesProfessors",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesProfessors", x => new { x.CourseId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_CoursesProfessors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesProfessors_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewProfessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Difficulty = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    WasAttendanceMandatory = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    WouldTakeAgain = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Dislikes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Saves = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewProfessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewProfessors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewProfessors_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewProfessors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewUniversities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Reputation = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Opportunities = table.Column<int>(type: "int", nullable: false),
                    Facilities = table.Column<int>(type: "int", nullable: false),
                    Internet = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Clubs = table.Column<int>(type: "int", nullable: false),
                    Social = table.Column<int>(type: "int", nullable: false),
                    Happiness = table.Column<int>(type: "int", nullable: false),
                    Safety = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Dislikes = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewUniversities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewUniversities_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewUniversities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsProfessorTags",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsProfessorTags", x => new { x.ReviewId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ReviewsProfessorTags_ReviewProfessorTags_TagId",
                        column: x => x.TagId,
                        principalTable: "ReviewProfessorTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsProfessorTags_ReviewProfessors_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "ReviewProfessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviewProfessorDislikes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviewProfessorDislikes", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_UserReviewProfessorDislikes_ReviewProfessors_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "ReviewProfessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviewProfessorDislikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserReviewProfessorLikes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviewProfessorLikes", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_UserReviewProfessorLikes_ReviewProfessors_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "ReviewProfessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviewProfessorLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSavedReviewProfessors",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSavedReviewProfessors", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_UserSavedReviewProfessors_ReviewProfessors_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "ReviewProfessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSavedReviewProfessors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserReviewUniversityDislikes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviewUniversityDislikes", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_UserReviewUniversityDislikes_ReviewUniversities_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "ReviewUniversities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviewUniversityDislikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserReviewUniversityLikes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviewUniversityLikes", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_UserReviewUniversityLikes_ReviewUniversities_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "ReviewUniversities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviewUniversityLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesProfessors_ProfessorId",
                table: "CoursesProfessors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_FacultyId",
                table: "Professors",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProfessors_CourseId",
                table: "ReviewProfessors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProfessors_ProfessorId",
                table: "ReviewProfessors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProfessors_UserId",
                table: "ReviewProfessors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsProfessorTags_TagId",
                table: "ReviewsProfessorTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewUniversities_UniversityId",
                table: "ReviewUniversities",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewUniversities_UserId",
                table: "ReviewUniversities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewProfessorDislikes_ReviewId",
                table: "UserReviewProfessorDislikes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewProfessorLikes_ReviewId",
                table: "UserReviewProfessorLikes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewUniversityDislikes_ReviewId",
                table: "UserReviewUniversityDislikes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewUniversityLikes_ReviewId",
                table: "UserReviewUniversityLikes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyId",
                table: "Users",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedReviewProfessors_ReviewId",
                table: "UserSavedReviewProfessors",
                column: "ReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesProfessors");

            migrationBuilder.DropTable(
                name: "ReviewsProfessorTags");

            migrationBuilder.DropTable(
                name: "UserReviewProfessorDislikes");

            migrationBuilder.DropTable(
                name: "UserReviewProfessorLikes");

            migrationBuilder.DropTable(
                name: "UserReviewUniversityDislikes");

            migrationBuilder.DropTable(
                name: "UserReviewUniversityLikes");

            migrationBuilder.DropTable(
                name: "UserSavedReviewProfessors");

            migrationBuilder.DropTable(
                name: "ReviewProfessorTags");

            migrationBuilder.DropTable(
                name: "ReviewUniversities");

            migrationBuilder.DropTable(
                name: "ReviewProfessors");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
