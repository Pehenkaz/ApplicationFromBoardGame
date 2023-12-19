using BoardGameCampaign.BL.Keepers.Entities;

namespace BoardGameCampaign.BL.Keepers;

public interface IKeepersProvider
{
	IEnumerable<KeeperModel> GetKeepers(KeepersModelFilter modelFilter = null);
	KeeperModel GetKeeperInfo(Guid keeperId);
}