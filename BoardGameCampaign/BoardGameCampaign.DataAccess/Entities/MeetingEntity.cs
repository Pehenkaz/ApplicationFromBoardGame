using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameCampaign.DataAccess.Entities
{
	[Table("meetings")]
	public class MeetingEntity : BaseEntity
	{
		public DateTime Date { get; set; }
		public TimeOnly TimeStart { get; set; }
		public TimeOnly? TimeFinish { get; set; }

		public int CampaignId { get; set; }
		public CampaignEntity Campaign { get; set; }
	}
}

