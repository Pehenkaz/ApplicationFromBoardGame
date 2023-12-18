using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
    [Table("campaign")]
    public class CampaignEntity : BaseEntity
    {
        public string Genre { get; set; }
        public int MaxNumberPlayers { get; set; }
        public int NumberEmployedPlaces { get; set; }
        public int NumberSessions { get; set; }
        public int Experience { get; set; }

        public int KeeperId { get; set; }
        public KeeperEntity Keeper { get; set; }
        public int GameId { get; set; }
        public GameEntity Game { get; set; }

        public virtual ICollection<CampaignHistoryEntity>? CampaignHistorys { get; set; }
        public virtual ICollection<MeetingEntity>? Meetings { get; set; }
    }
}