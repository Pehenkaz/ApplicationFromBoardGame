using BoardGameCampaign.BL.Campaign.Entities;

namespace BoardGameCampaign.BL.Campaign;

public interface ICampaignsProvider
{
	IEnumerable<CampaignModel> GetCampaigns(CampaignModelFilter modelFilter = null);
	CampaignModel GetCampaignInfo(Guid campaignId);
}