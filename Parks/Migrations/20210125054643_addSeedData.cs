using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Migrations
{
    public partial class addSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NationalParks",
                columns: table => new
                {
                    NationalParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalParks", x => x.NationalParkId);
                });

            migrationBuilder.CreateTable(
                name: "StateParks",
                columns: table => new
                {
                    StateParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateParks", x => x.StateParkId);
                });

            migrationBuilder.InsertData(
                table: "NationalParks",
                columns: new[] { "NationalParkId", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Weird-looking trees", "Joshua Tree NP", "CA" },
                    { 2, "Weird-looking rocks", "Arches NP", "UT" },
                    { 3, "Weird-looking Gators", "Everglades NP", "FL" }
                });

            migrationBuilder.InsertData(
                table: "StateParks",
                columns: new[] { "StateParkId", "Description", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Weird-looking trees", "IN", "Turkey Run SP" },
                    { 2, "Weird-looking lizards", "UT", "Snow Canyon SP" },
                    { 3, "Weird-looking plants", "NV", "Valley of Fire SP" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationalParks");

            migrationBuilder.DropTable(
                name: "StateParks");
        }
    }
}
