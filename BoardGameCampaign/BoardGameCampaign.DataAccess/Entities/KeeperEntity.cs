using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
    [Table("keepers")]
    public class KeeperEntity : UserEntity
    {
        public string Nickname { get; set; }

        public virtual ICollection<CampaignEntity>? Campaigns { get; set; }
    }
}