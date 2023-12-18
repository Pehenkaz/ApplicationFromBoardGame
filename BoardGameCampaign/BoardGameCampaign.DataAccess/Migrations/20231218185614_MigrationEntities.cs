using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameCampaign.DataAccess.BoardGameCampaign.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminEntityId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admins_admins_AdminEntityId",
                        column: x => x.AdminEntityId,
                        principalTable: "admins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "keepers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeeperEntityId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keepers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_keepers_keepers_KeeperEntityId",
                        column: x => x.KeeperEntityId,
                        principalTable: "keepers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerEntityId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_players_players_PlayerEntityId",
                        column: x => x.PlayerEntityId,
                        principalTable: "players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminEntityKeeperEntity",
                columns: table => new
                {
                    AdminsId = table.Column<int>(type: "int", nullable: false),
                    KeepersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEntityKeeperEntity", x => new { x.AdminsId, x.KeepersId });
                    table.ForeignKey(
                        name: "FK_AdminEntityKeeperEntity_admins_AdminsId",
                        column: x => x.AdminsId,
                        principalTable: "admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminEntityKeeperEntity_keepers_KeepersId",
                        column: x => x.KeepersId,
                        principalTable: "keepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "campaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxNumberPlayers = table.Column<int>(type: "int", nullable: false),
                    NumberEmployedPlaces = table.Column<int>(type: "int", nullable: false),
                    NumberSessions = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    KeeperId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_campaign_game_GameId",
                        column: x => x.GameId,
                        principalTable: "game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_campaign_keepers_KeeperId",
                        column: x => x.KeeperId,
                        principalTable: "keepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminEntityPlayerEntity",
                columns: table => new
                {
                    AdminsId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEntityPlayerEntity", x => new { x.AdminsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_AdminEntityPlayerEntity_admins_AdminsId",
                        column: x => x.AdminsId,
                        principalTable: "admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminEntityPlayerEntity_players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: true),
                    NumberPlayers = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignRequests_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeeperEntityPlayerEntity",
                columns: table => new
                {
                    KeepersId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeeperEntityPlayerEntity", x => new { x.KeepersId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_KeeperEntityPlayerEntity_keepers_KeepersId",
                        column: x => x.KeepersId,
                        principalTable: "keepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeeperEntityPlayerEntity_players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questions_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignHistories_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignHistories_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeFinish = table.Column<TimeSpan>(type: "time", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meetings_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminEntityKeeperEntity_KeepersId",
                table: "AdminEntityKeeperEntity",
                column: "KeepersId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminEntityPlayerEntity_PlayersId",
                table: "AdminEntityPlayerEntity",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_admins_AdminEntityId",
                table: "admins",
                column: "AdminEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_admins_Login",
                table: "admins",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_campaign_ExternalId",
                table: "campaign",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_campaign_GameId",
                table: "campaign",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_campaign_KeeperId",
                table: "campaign",
                column: "KeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignHistories_CampaignId",
                table: "CampaignHistories",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignHistories_ExternalId",
                table: "CampaignHistories",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignHistories_PlayerId_CampaignId",
                table: "CampaignHistories",
                columns: new[] { "PlayerId", "CampaignId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRequests_ExternalId",
                table: "CampaignRequests",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRequests_PlayerId",
                table: "CampaignRequests",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_game_ExternalId",
                table: "game",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeeperEntityPlayerEntity_PlayersId",
                table: "KeeperEntityPlayerEntity",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_keepers_ExternalId",
                table: "keepers",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_keepers_KeeperEntityId",
                table: "keepers",
                column: "KeeperEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_keepers_Nickname",
                table: "keepers",
                column: "Nickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_meetings_CampaignId",
                table: "meetings",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_meetings_ExternalId",
                table: "meetings",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_ExternalId",
                table: "players",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_Login",
                table: "players",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_PlayerEntityId",
                table: "players",
                column: "PlayerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_ExternalId",
                table: "questions",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_PlayerId",
                table: "questions",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEntityKeeperEntity");

            migrationBuilder.DropTable(
                name: "AdminEntityPlayerEntity");

            migrationBuilder.DropTable(
                name: "CampaignHistories");

            migrationBuilder.DropTable(
                name: "CampaignRequests");

            migrationBuilder.DropTable(
                name: "KeeperEntityPlayerEntity");

            migrationBuilder.DropTable(
                name: "meetings");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "campaign");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "keepers");
        }
    }
}
