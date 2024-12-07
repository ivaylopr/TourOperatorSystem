using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourOperatorSystem.Infrastructure.Migrations
{
    public partial class DataModelsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Agent identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Agent phone number"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User who is agent identifier"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true, comment: "Rating of the agent")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Agent class");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Room title"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Room description"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Room price"),
                    AdditionalExtras = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Additional room extras"),
                    Count = table.Column<int>(type: "int", nullable: false, comment: "rooms available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                },
                comment: "Room class");

            migrationBuilder.CreateTable(
                name: "VacationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type of the vacation"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "Description of the type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationCategories", x => x.Id);
                },
                comment: "Category class for vacations");

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Hotel identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Hotel name"),
                    HotelReview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Hotel review and presentation"),
                    Spa = table.Column<bool>(type: "bit", nullable: false, comment: "Spa available"),
                    Pool = table.Column<bool>(type: "bit", nullable: false, comment: "Pool available"),
                    AllInclusivePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "All inclusive additional price to the room offer"),
                    ChildrenAnimators = table.Column<bool>(type: "bit", nullable: false, comment: "Children animation available"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Hotel location"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "Hotel Total capacity"),
                    CategoryStars = table.Column<int>(type: "int", nullable: false, comment: "Category stars of the hotel"),
                    Rating = table.Column<double>(type: "float", nullable: true, comment: "Rating of the hotel"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VacationCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_VacationCategories_VacationCategoryId",
                        column: x => x.VacationCategoryId,
                        principalTable: "VacationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Hotel class");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Comment identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Review for the hotel or for the agent"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User who give the review"),
                    Rating = table.Column<int>(type: "int", nullable: true, comment: "Rating given by the user creator of the review"),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                },
                comment: "Class for comments and reviews by the users");

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => new { x.HotelId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonalEmployments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Job title"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Job description"),
                    HourlyWage = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Payment per hour"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data for starting job"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End date for the job"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent responsible for the offer"),
                    HotelId = table.Column<int>(type: "int", nullable: false, comment: "Hotel who is offering the season job"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonalEmployments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonalEmployments_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonalEmployments_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Season job class");

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vacation identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Vacation Title"),
                    AllInclusive = table.Column<bool>(type: "bit", nullable: true, comment: "Is all inclusive option added to the vacation"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    VacationCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EnrollmentDeadline = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Vacation enrollment deadline"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Vacation start date"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Vacation end date/leaving"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Vacation description"),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Location of the vacation"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent who is responsive for the vacation"),
                    HotelId = table.Column<int>(type: "int", nullable: false, comment: "Hotel identifier of the holiday")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacations_VacationCategories_VacationCategoryId",
                        column: x => x.VacationCategoryId,
                        principalTable: "VacationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Vacation class");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Candidate identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User-Candidate"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the candidate"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Candidate email"),
                    IsAvaileble = table.Column<bool>(type: "bit", nullable: false, comment: "Is the candidate availeble"),
                    SeasonalEmploymentId = table.Column<int>(type: "int", nullable: false),
                    ShortRepresentAndSkills = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false, comment: "Short presentation and skills of the candidate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_SeasonalEmployments_SeasonalEmploymentId",
                        column: x => x.SeasonalEmploymentId,
                        principalTable: "SeasonalEmployments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Candidate class");

            migrationBuilder.CreateTable(
                name: "HotelVacations",
                columns: table => new
                {
                    HodelId = table.Column<int>(type: "int", nullable: false),
                    VacationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelVacations", x => new { x.VacationId, x.HodelId });
                    table.ForeignKey(
                        name: "FK_HotelVacations_Hotels_HodelId",
                        column: x => x.HodelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelVacations_Vacations_VacationId",
                        column: x => x.VacationId,
                        principalTable: "Vacations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationCustomers",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationCustomers", x => new { x.VacationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_VacationCustomers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationCustomers_Vacations_VacationId",
                        column: x => x.VacationId,
                        principalTable: "Vacations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_SeasonalEmploymentId",
                table: "Candidates",
                column: "SeasonalEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_UserId",
                table: "Candidates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AgentId",
                table: "Comment",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_HotelId",
                table: "Comment",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_VacationCategoryId",
                table: "Hotels",
                column: "VacationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelVacations_HodelId",
                table: "HotelVacations",
                column: "HodelId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonalEmployments_AgentId",
                table: "SeasonalEmployments",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonalEmployments_HotelId",
                table: "SeasonalEmployments",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationCustomers_UserId",
                table: "VacationCustomers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_AgentId",
                table: "Vacations",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_HotelId",
                table: "Vacations",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_VacationCategoryId",
                table: "Vacations",
                column: "VacationCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "HotelVacations");

            migrationBuilder.DropTable(
                name: "VacationCustomers");

            migrationBuilder.DropTable(
                name: "SeasonalEmployments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "VacationCategories");
        }
    }
}
