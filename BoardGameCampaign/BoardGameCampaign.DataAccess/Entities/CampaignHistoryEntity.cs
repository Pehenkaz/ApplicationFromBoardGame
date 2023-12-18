namespace BoardGameCampaign.DataAccess.Entities
{
    public class CampaignHistoryEntity : BaseEntity
    {
        public DateTime DateStart { get; set; }
        public DateTime? DateFinish { get; set; }

        public int CampaignId { get; set; }
        public CampaignEntity Campaign { get; set; }
        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}