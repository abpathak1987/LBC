using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CapitolareAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalBackground = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manuscripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreservationCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manuscripts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonorInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrengthScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonorInterests_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonorScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    AffinityScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CapacityScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EngagementProbability = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PredictedDonationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonorScores_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManuscriptCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManuscriptCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManuscriptCategories_Manuscripts_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManuscriptStoryAngles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false),
                    StoryAngle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManuscriptStoryAngles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManuscriptStoryAngles_Manuscripts_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManuscriptAffinities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorScoreId = table.Column<int>(type: "int", nullable: false),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false),
                    AffinityScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManuscriptAffinities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManuscriptAffinities_DonorScores_DonorScoreId",
                        column: x => x.DonorScoreId,
                        principalTable: "DonorScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManuscriptAffinities_Manuscripts_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Donors",
                columns: new[] { "Id", "CreatedDate", "Email", "EstimatedCapacity", "FirstName", "LastName", "Location", "ProfessionalBackground" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "e.hughes@example.com", 50000m, "Eleanor", "Hughes", "Boston, MA", "Professor of Medieval Literature" },
                    { 2, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "m.chen@example.com", 200000m, "Michael", "Chen", "San Francisco, CA", "Tech Executive" },
                    { 3, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "s.lombardi@example.com", 150000m, "Sophia", "Lombardi", "New York, NY", "Art Collector" },
                    { 4, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "r.johnson@example.com", 100000m, "Robert", "Johnson", "Chicago, IL", "Pharmaceutical Executive" },
                    { 5, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "j.reed@example.com", 30000m, "Julia", "Reed", "Washington, DC", "Religious Studies Professor" }
                });

            migrationBuilder.InsertData(
                table: "Manuscripts",
                columns: new[] { "Id", "Condition", "Description", "Period", "PreservationCost", "Title" },
                values: new object[,]
                {
                    { 1, "Fragile", "One of the oldest surviving biblical manuscripts, contains rare passages of early Latin translations.", "6th Century", 75000m, "Codex Veronensis" },
                    { 2, "Poor", "Contains previously unknown works of Archimedes, overwritten by later religious texts.", "10th Century", 120000m, "Archimedes Palimpsest" },
                    { 3, "Good", "Rare early manuscript of Dante's masterpiece with unique illustrations.", "14th Century", 45000m, "Dante's Divine Comedy First Edition" },
                    { 4, "Fair", "Lavishly illustrated Flemish manuscript with exceptional detail and artistry.", "15th Century", 95000m, "Breviarium Grimani" },
                    { 5, "Poor", "Rare medical treatise combining Greek, Arabic and early Italian medical knowledge.", "12th Century", 85000m, "Verona Medical Codex" }
                });

            migrationBuilder.InsertData(
                table: "DonorInterests",
                columns: new[] { "Id", "Category", "DonorId", "StrengthScore" },
                values: new object[,]
                {
                    { 1, "Medieval Literature", 1, 9 },
                    { 2, "Preservation", 1, 7 },
                    { 3, "Italian Culture", 1, 8 },
                    { 4, "Digital Preservation", 2, 9 },
                    { 5, "Ancient Science", 2, 8 },
                    { 6, "Technology History", 2, 7 },
                    { 7, "Italian Renaissance", 3, 9 },
                    { 8, "Art History", 3, 9 },
                    { 9, "Religious Art", 3, 6 },
                    { 10, "Medical History", 4, 8 },
                    { 11, "Ancient Science", 4, 7 },
                    { 12, "Rare Books", 4, 5 },
                    { 13, "Early Christianity", 5, 9 },
                    { 14, "Biblical Studies", 5, 9 },
                    { 15, "Ancient Languages", 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "DonorScores",
                columns: new[] { "Id", "AffinityScore", "CapacityScore", "DonorId", "EngagementProbability", "PredictedDonationAmount" },
                values: new object[,]
                {
                    { 1, 8.5m, 7.2m, 1, 0.75m, 15000m },
                    { 2, 7.8m, 9.0m, 2, 0.65m, 25000m },
                    { 3, 8.2m, 8.7m, 3, 0.82m, 30000m },
                    { 4, 7.1m, 8.3m, 4, 0.60m, 18000m },
                    { 5, 8.9m, 6.1m, 5, 0.88m, 12000m }
                });

            migrationBuilder.InsertData(
                table: "ManuscriptCategories",
                columns: new[] { "Id", "Category", "ManuscriptId" },
                values: new object[,]
                {
                    { 1, "Biblical", 1 },
                    { 2, "Latin", 1 },
                    { 3, "Early Christianity", 1 },
                    { 4, "Mathematics", 2 },
                    { 5, "Science", 2 },
                    { 6, "Ancient Greece", 2 },
                    { 7, "Literature", 3 },
                    { 8, "Italian Renaissance", 3 },
                    { 9, "Poetry", 3 },
                    { 10, "Art", 4 },
                    { 11, "Religious", 4 },
                    { 12, "Illuminated Manuscript", 4 },
                    { 13, "Medicine", 5 },
                    { 14, "Science", 5 },
                    { 15, "Medieval", 5 }
                });

            migrationBuilder.InsertData(
                table: "ManuscriptStoryAngles",
                columns: new[] { "Id", "ManuscriptId", "StoryAngle" },
                values: new object[,]
                {
                    { 1, 1, "Biblical Heritage" },
                    { 2, 1, "Earliest Christian Writings" },
                    { 3, 1, "Linguistic Evolution" },
                    { 4, 2, "Scientific Discovery" },
                    { 5, 2, "Preservation Technology" },
                    { 6, 2, "Lost Knowledge" },
                    { 7, 3, "Italian Cultural Heritage" },
                    { 8, 3, "Literary Milestone" },
                    { 9, 3, "Artistic Collaboration" },
                    { 10, 4, "Artistic Excellence" },
                    { 11, 4, "Religious Devotion" },
                    { 12, 4, "Cultural Exchange" },
                    { 13, 5, "Medical History" },
                    { 14, 5, "Cross-Cultural Knowledge" },
                    { 15, 5, "Scientific Preservation" }
                });

            migrationBuilder.InsertData(
                table: "ManuscriptAffinities",
                columns: new[] { "Id", "AffinityScore", "DonorScoreId", "ManuscriptId" },
                values: new object[,]
                {
                    { 1, 9.1m, 1, 3 },
                    { 2, 7.8m, 1, 1 },
                    { 3, 6.5m, 1, 4 },
                    { 4, 8.9m, 2, 2 },
                    { 5, 7.2m, 2, 5 },
                    { 6, 4.3m, 2, 1 },
                    { 7, 9.3m, 3, 4 },
                    { 8, 8.7m, 3, 3 },
                    { 9, 3.5m, 3, 2 },
                    { 10, 9.0m, 4, 5 },
                    { 11, 6.8m, 4, 2 },
                    { 12, 4.1m, 4, 1 },
                    { 13, 9.5m, 5, 1 },
                    { 14, 7.2m, 5, 4 },
                    { 15, 4.8m, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonorInterests_DonorId",
                table: "DonorInterests",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorScores_DonorId",
                table: "DonorScores",
                column: "DonorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManuscriptAffinities_DonorScoreId",
                table: "ManuscriptAffinities",
                column: "DonorScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ManuscriptAffinities_ManuscriptId",
                table: "ManuscriptAffinities",
                column: "ManuscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_ManuscriptCategories_ManuscriptId",
                table: "ManuscriptCategories",
                column: "ManuscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_ManuscriptStoryAngles_ManuscriptId",
                table: "ManuscriptStoryAngles",
                column: "ManuscriptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorInterests");

            migrationBuilder.DropTable(
                name: "ManuscriptAffinities");

            migrationBuilder.DropTable(
                name: "ManuscriptCategories");

            migrationBuilder.DropTable(
                name: "ManuscriptStoryAngles");

            migrationBuilder.DropTable(
                name: "DonorScores");

            migrationBuilder.DropTable(
                name: "Manuscripts");

            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
