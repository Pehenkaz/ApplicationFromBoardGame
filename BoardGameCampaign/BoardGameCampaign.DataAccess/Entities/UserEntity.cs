namespace BoardGameCampaign.DataAccess.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? Patronymic { get; set; }
        public int Age { get; set; }
       
        public virtual ICollection<KeeperEntity>? Keepers { get; set; }
        public virtual ICollection<PlayerEntity>? Players { get; set; }
        public virtual ICollection<AdminEntity> Admins { get; set; }
    }
}