namespace BoardGameCampaign.BL.Campaign.Entities;

public class CampaignModelFilter
{
    public int? MinimumNumberSessions { get; set; }
    public int? MaximumNumberSessions { get; set; }

    public int? MinimumExperience { get; set; }
    public int? MaximumExperience { get; set; }

    public int? MinimumMaxNumberPlayers { get; set; } 
    public int? MaximumMaxNumberPlayers { get; set; }

    public int? MinimumNumberEmployedPlaces { get; set; }
    public int? MaximumNumberEmployedPlaces { get; set; }
}