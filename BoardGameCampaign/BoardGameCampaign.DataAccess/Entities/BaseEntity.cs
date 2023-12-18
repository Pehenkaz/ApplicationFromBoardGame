using System.ComponentModel.DataAnnotations;

namespace BoardGameCampaign.DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } //ключ в бд

        public Guid ExternalId { get; set; } // unique index - unique optional
        public DateTime ModificationTime { get; set; } // optional
        public DateTime CreationTime { get; set; } //optional

        public bool IsNew()
        {
            return ExternalId == Guid.Empty;
        }

        public void Init()
        {
            ExternalId = Guid.NewGuid();
            ModificationTime = DateTime.Now;
            CreationTime = DateTime.Now;
        }
    }
}