using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
    [Table("questions")]
    public class QuestionEntity : BaseEntity
    {
        public string Question { get; set; }

        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}

