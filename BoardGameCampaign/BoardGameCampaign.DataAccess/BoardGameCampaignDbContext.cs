using BoardGameCampaign.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGameCampaign.DataAccess
{
    public class BoardGameCampaignDbContext : DbContext
    {
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<CampaignEntity> Campaigns { get; set; }
        public DbSet<CampaignHistoryEntity> CampaignHistories { get; set; }
        public DbSet<CampaignRequestEntity> CampaignRequests { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<KeeperEntity> Keepers { get; set; }
        public DbSet<MeetingEntity> Meetings { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }

        public BoardGameCampaignDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.Login).IsUnique();

            modelBuilder.Entity<PlayerEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PlayerEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<PlayerEntity>().HasIndex(x => x.Login).IsUnique();

            modelBuilder.Entity<KeeperEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<KeeperEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<KeeperEntity>().HasIndex(x => x.Nickname).IsUnique();

            modelBuilder.Entity<QuestionEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<QuestionEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<QuestionEntity>().HasOne(x => x.Player)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.PlayerId);

            modelBuilder.Entity<CampaignRequestEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CampaignRequestEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<CampaignRequestEntity>().HasOne(x => x.Player)
                .WithMany(x => x.CampaignRequests)
                .HasForeignKey(x => x.PlayerId);

            modelBuilder.Entity<GameEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<GameEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<CampaignEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CampaignEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<CampaignEntity>().HasOne(x => x.Game)
                .WithMany(x => x.Campaigns)
                .HasForeignKey(x => x.GameId);
            modelBuilder.Entity<CampaignEntity>().HasOne(x => x.Keeper)
                .WithMany(x => x.Campaigns)
                .HasForeignKey(x => x.KeeperId);

            modelBuilder.Entity<CampaignHistoryEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CampaignHistoryEntity>().HasIndex(x => new { x.PlayerId, x.CampaignId }).IsUnique();
            modelBuilder.Entity<CampaignHistoryEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<CampaignHistoryEntity>().HasOne(x => x.Player)
                .WithMany(x => x.CampaignHistories)
                .HasForeignKey(x => x.PlayerId);
            modelBuilder.Entity<CampaignHistoryEntity>().HasOne(x => x.Campaign)
                .WithMany(x => x.CampaignHistorys)
                .HasForeignKey(x => x.CampaignId);

            modelBuilder.Entity<MeetingEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<MeetingEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<MeetingEntity>().HasOne(x => x.Campaign)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.CampaignId);
        }
    }
}