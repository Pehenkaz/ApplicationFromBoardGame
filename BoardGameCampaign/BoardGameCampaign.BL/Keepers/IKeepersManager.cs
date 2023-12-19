using BoardGameCampaign.BL.Keepers.Entities;

namespace BoardGameCampaign.BL.Keepers;

public interface IKeepersManager
{
    KeeperModel CreateKeeper(CreateKeeperModel model);
    //DeleteKeeper(id);
    //UpdateKeeper(id, model);
}