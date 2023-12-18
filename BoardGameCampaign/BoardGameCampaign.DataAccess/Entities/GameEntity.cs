using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
    [Table("game")]
    public class GameEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Edition { get; set; }

        public virtual ICollection<CampaignEntity>? Campaigns { get; set; }
    }
}