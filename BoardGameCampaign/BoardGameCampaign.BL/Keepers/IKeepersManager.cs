using BoardGameCampaign.BL.Keepers.Entities;

namespace BoardGameCampaign.BL.Keepers;

public interface IKeepersManager
{
    KeeperModel CreateKeeper(CreateKeeperModel model);
    void DeleteKeeper(Guid keeperId);
    KeeperModel UpdateKeeper(Guid keeperId, CreateKeeperModel model);
}