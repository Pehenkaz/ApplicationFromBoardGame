using BoardGameCampaign.BL.Campaign.Entities;

namespace BoardGameCampaign.BL.Campaign;

public interface ICampaignManager
{
	CampaignModel CreateCampaign(CreateCampaignModel model);
	void DeleteCampaign(Guid Id);
}