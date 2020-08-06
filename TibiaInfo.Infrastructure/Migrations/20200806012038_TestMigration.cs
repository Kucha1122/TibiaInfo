using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TibiaInfo.Infrastructure.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterHuntingInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonalLoot = table.Column<double>(nullable: false),
                    PersonalSupplies = table.Column<double>(nullable: false),
                    PersonalBalance = table.Column<double>(nullable: false),
                    Damage = table.Column<double>(nullable: false),
                    Healing = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterHuntingInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HuntingInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Session = table.Column<DateTime>(nullable: false),
                    Loot = table.Column<double>(nullable: false),
                    Supplies = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TibiaCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Vocation = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    AchievementPoints = table.Column<int>(nullable: false),
                    World = table.Column<string>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    AccountStatus = table.Column<string>(nullable: true),
                    LoyaltyTitle = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TibiaCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TibiaCharacters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Huntings",
                columns: table => new
                {
                    TibiaCharacterId = table.Column<Guid>(nullable: false),
                    CharacterHuntingInfoId = table.Column<Guid>(nullable: false),
                    HuntingInfoId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huntings", x => new { x.TibiaCharacterId, x.CharacterHuntingInfoId, x.HuntingInfoId });
                    table.ForeignKey(
                        name: "FK_Huntings_CharacterHuntingInfos_CharacterHuntingInfoId",
                        column: x => x.CharacterHuntingInfoId,
                        principalTable: "CharacterHuntingInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Huntings_HuntingInfos_HuntingInfoId",
                        column: x => x.HuntingInfoId,
                        principalTable: "HuntingInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Huntings_TibiaCharacters_TibiaCharacterId",
                        column: x => x.TibiaCharacterId,
                        principalTable: "TibiaCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huntings_CharacterHuntingInfoId",
                table: "Huntings",
                column: "CharacterHuntingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Huntings_HuntingInfoId",
                table: "Huntings",
                column: "HuntingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TibiaCharacters_UserId",
                table: "TibiaCharacters",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huntings");

            migrationBuilder.DropTable(
                name: "CharacterHuntingInfos");

            migrationBuilder.DropTable(
                name: "HuntingInfos");

            migrationBuilder.DropTable(
                name: "TibiaCharacters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
