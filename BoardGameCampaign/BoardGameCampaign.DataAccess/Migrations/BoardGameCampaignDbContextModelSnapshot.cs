﻿// <auto-generated />
using System;
using BoardGameCampaign.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameCampaign.DataAccess.BoardGameCampaign.DataAccess.Migrations
{
    [DbContext(typeof(BoardGameCampaignDbContext))]
    partial class BoardGameCampaignDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminEntityKeeperEntity", b =>
                {
                    b.Property<int>("AdminsId")
                        .HasColumnType("int");

                    b.Property<int>("KeepersId")
                        .HasColumnType("int");

                    b.HasKey("AdminsId", "KeepersId");

                    b.HasIndex("KeepersId");

                    b.ToTable("AdminEntityKeeperEntity");
                });

            modelBuilder.Entity("AdminEntityPlayerEntity", b =>
                {
                    b.Property<int>("AdminsId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("AdminsId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("AdminEntityPlayerEntity");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdminEntityId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminEntityId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("admins");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.CampaignEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KeeperId")
                        .HasColumnType("int");

                    b.Property<int>("MaxNumberPlayers")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberEmployedPlaces")
                        .HasColumnType("int");

                    b.Property<int>("NumberSessions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("GameId");

                    b.HasIndex("KeeperId");

                    b.ToTable("campaign");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.CampaignHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("PlayerId", "CampaignId")
                        .IsUnique();

                    b.ToTable("CampaignHistories");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.CampaignRequestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Duration")
                        .HasColumnType("float");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NumberPlayers")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("PlayerId");

                    b.ToTable("CampaignRequests");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("game");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.KeeperEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KeeperEntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("KeeperEntityId");

                    b.HasIndex("Nickname")
                        .IsUnique();

                    b.ToTable("keepers");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.MeetingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("TimeFinish")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeStart")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("meetings");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerEntityId")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("PlayerEntityId");

                    b.ToTable("players");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.QuestionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("PlayerId");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("KeeperEntityPlayerEntity", b =>
                {
                    b.Property<int>("KeepersId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("KeepersId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("KeeperEntityPlayerEntity");
                });

            modelBuilder.Entity("AdminEntityKeeperEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.AdminEntity", null)
                        .WithMany()
                        .HasForeignKey("AdminsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameCampaign.DataAccess.Entities.KeeperEntity", null)
                        .WithMany()
                        .HasForeignKey("KeepersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdminEntityPlayerEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.AdminEntity", null)
                        .WithMany()
                        .HasForeignKey("AdminsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameCampaign.DataAccess.Entities.PlayerEntity", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.AdminEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.AdminEntity", null)
                        .WithMany("Admins")
                        .HasForeignKey("AdminEntityId");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.CampaignEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.GameEntity", "Game")
                        .WithMany("Campaigns")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameCampaign.DataAccess.Entities.KeeperEntity", "Keeper")
                        .WithMany("Campaigns")
                        .HasForeignKey("KeeperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Keeper");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.CampaignHistoryEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.CampaignEntity", "Campaign")
                        .WithMany("CampaignHistorys")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameCampaign.DataAccess.Entities.PlayerEntity", "Player")
                        .WithMany("CampaignHistories")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.CampaignRequestEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.PlayerEntity", "Player")
                        .WithMany("CampaignRequests")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.KeeperEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.KeeperEntity", null)
                        .WithMany("Keepers")
                        .HasForeignKey("KeeperEntityId");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.MeetingEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.CampaignEntity", "Campaign")
                        .WithMany("Meetings")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.PlayerEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.PlayerEntity", null)
                        .WithMany("Players")
                        .HasForeignKey("PlayerEntityId");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.QuestionEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.PlayerEntity", "Player")
                        .WithMany("Questions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("KeeperEntityPlayerEntity", b =>
                {
                    b.HasOne("BoardGameCampaign.DataAccess.Entities.KeeperEntity", null)
                        .WithMany()
                        .HasForeignKey("KeepersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameCampaign.DataAccess.Entities.PlayerEntity", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.AdminEntity", b =>
                {
                    b.Navigation("Admins");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.CampaignEntity", b =>
                {
                    b.Navigation("CampaignHistorys");

                    b.Navigation("Meetings");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.GameEntity", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.KeeperEntity", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Keepers");
                });

            modelBuilder.Entity("BoardGameCampaign.DataAccess.Entities.PlayerEntity", b =>
                {
                    b.Navigation("CampaignHistories");

                    b.Navigation("CampaignRequests");

                    b.Navigation("Players");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
