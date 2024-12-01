using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL_PMS.Migrations
{
    /// <inheritdoc />
    public partial class AddAssement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentDetails",
                columns: table => new
                {
                    AssId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentDetails", x => x.AssId);
                });

            migrationBuilder.CreateTable(
                name: "CaseStudyDetails",
                columns: table => new
                {
                    CsSID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    ReviewStatus = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStudyDetails", x => x.CsSID);
                });

            migrationBuilder.CreateTable(
                name: "CaseStudySolutions",
                columns: table => new
                {
                    CSSID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSID = table.Column<int>(type: "int", nullable: false),
                    CompedencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStudySolutions", x => x.CSSID);
                });

            migrationBuilder.CreateTable(
                name: "CompetencyDetails",
                columns: table => new
                {
                    CompId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetencyDetails", x => x.CompId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentDetails");

            migrationBuilder.DropTable(
                name: "CaseStudyDetails");

            migrationBuilder.DropTable(
                name: "CaseStudySolutions");

            migrationBuilder.DropTable(
                name: "CompetencyDetails");
        }
    }
}
