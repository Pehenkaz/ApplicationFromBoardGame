using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
    [Table("admins")]
    public class AdminEntity : UserEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}