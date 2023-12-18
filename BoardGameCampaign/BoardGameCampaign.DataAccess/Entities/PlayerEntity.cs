using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
    [Table("players")]
    public class PlayerEntity : UserEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<CampaignRequestEntity>? CampaignRequests { get; set; }
        public virtual ICollection<QuestionEntity>? Questions { get; set; }
        public virtual ICollection<CampaignHistoryEntity>? CampaignHistories { get; set; }
    }
}