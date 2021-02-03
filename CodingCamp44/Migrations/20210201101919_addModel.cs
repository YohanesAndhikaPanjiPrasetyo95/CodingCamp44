using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingCamp44.Migrations
{
    public partial class addModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_job",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profession = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_person",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_person", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_university",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_university", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_account",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_account_tb_m_person_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_person",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    University_Id = table.Column<int>(nullable: false),
                    Degree = table.Column<string>(nullable: false),
                    GPA = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_education_tb_m_university_University_Id",
                        column: x => x.University_Id,
                        principalTable: "tb_m_university",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_profiling",
                columns: table => new
                {
                    NIK = table.Column<string>(nullable: false),
                    Education_Id = table.Column<int>(nullable: false),
                    Job_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_profiling_tb_m_education_Education_Id",
                        column: x => x.Education_Id,
                        principalTable: "tb_m_education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_profiling_tb_m_job_Job_Id",
                        column: x => x.Job_Id,
                        principalTable: "tb_m_job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_profiling_tb_m_person_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_person",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_education_University_Id",
                table: "tb_m_education",
                column: "University_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_profiling_Education_Id",
                table: "tb_m_profiling",
                column: "Education_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_profiling_Job_Id",
                table: "tb_m_profiling",
                column: "Job_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_account");

            migrationBuilder.DropTable(
                name: "tb_m_profiling");

            migrationBuilder.DropTable(
                name: "tb_m_role");

            migrationBuilder.DropTable(
                name: "tb_m_education");

            migrationBuilder.DropTable(
                name: "tb_m_job");

            migrationBuilder.DropTable(
                name: "tb_m_person");

            migrationBuilder.DropTable(
                name: "tb_m_university");
        }
    }
}
