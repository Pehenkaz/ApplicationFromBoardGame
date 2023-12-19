using BoardGameCampaign.BL.Campaign.Entities;

namespace BoardGameCampaign.BL.Campaign;

public interface ICampaignsManager
{
	CampaignModel CreateCampaign(CreateCampaignModel model);
	void DeleteCampaign(Guid Id);
    CampaignModel UpdateKeeper(Guid keeperId, CreateCampaignModel model);
}