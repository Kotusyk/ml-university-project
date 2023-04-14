using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalRecognizer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Address = table.Column<string>(type: "varchar", nullable: false),
                    Phone = table.Column<string>(type: "varchar", nullable: false),
                    QuantityOfPets = table.Column<int>(type: "int", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Email = table.Column<string>(type: "varchar", nullable: false),
                    Login = table.Column<string>(type: "varchar", nullable: false),
                    Password = table.Column<string>(type: "varchar", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Colour = table.Column<string>(type: "varchar", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "varchar", nullable: false),
                    Sterilized = table.Column<bool>(type: "bit", nullable: false),
                    Passport = table.Column<bool>(type: "bit", nullable: false),
                    CurrentShelterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Shelters_CurrentShelterId",
                        column: x => x.CurrentShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CurrentShelterId",
                table: "Pets",
                column: "CurrentShelterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
