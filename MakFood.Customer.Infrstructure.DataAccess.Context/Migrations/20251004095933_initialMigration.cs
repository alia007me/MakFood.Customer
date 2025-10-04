using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Customer.Infrstructure.DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NickNameOfReceiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickNameOfSender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtherUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    ActiveFriend = table.Column<bool>(type: "bit", nullable: false),
                    MatchingState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identity_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identity_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identity_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identity_BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Account_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account_JoinDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Account_ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_Badge = table.Column<int>(type: "int", nullable: false),
                    Contactinfo_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Contactinfo_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contactinfo_Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<long>(type: "bigint", nullable: false),
                    UnitNo = table.Column<long>(type: "bigint", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Friendship");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
