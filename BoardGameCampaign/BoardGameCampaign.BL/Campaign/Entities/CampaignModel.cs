using BoardGameCampaign.DataAccess.Entities;

namespace BoardGameCampaign.BL.Campaign.Entities;

public class CampaignModel
{
    public Guid Id { get; set; }
    public int MaxNumberPlayers { get; set; }
    public int NumberEmployedPlaces { get; set; }
    public int NumberSessions { get; set; }
    public int Experience { get; set; }
    public KeeperEntity Keeper { get; set; }
    public GameEntity Game { get; set; }
}