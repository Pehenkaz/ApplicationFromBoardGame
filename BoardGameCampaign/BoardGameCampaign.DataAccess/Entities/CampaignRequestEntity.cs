using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
    [Table("CampaignRequests")]
    public class CampaignRequestEntity : BaseEntity
    {
        public string Genre { get; set; }
        public double? Duration { get; set; }
        public int? NumberPlayers { get; set; }

        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}

