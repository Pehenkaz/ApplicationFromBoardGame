using AutoMapper;
using BoardGameCampaign.BL.Campaign.Entities;
using BoardGameCampaign.DataAccess;
using BoardGameCampaign.DataAccess.Entities;

namespace BoardGameCampaign.BL.Campaign;

public class CampaignsProvider : ICampaignsProvider
{
    private readonly IRepository<CampaignEntity> _campaignsRepository;
    private readonly IMapper _mapper;

    public CampaignsProvider(IRepository<CampaignEntity> campaignsRepository, IMapper mapper)
    {
        _campaignsRepository = campaignsRepository;
        _mapper = mapper;
    }

    public IEnumerable<CampaignModel> GetCampaigns(CampaignModelFilter modelFilter = null)
    {
        var minimumNumberSessions = modelFilter?.MinimumNumberSessions;
        var maximumNumberSessions = modelFilter?.MaximumNumberSessions;

        var minimumExperience = modelFilter?.MinimumExperience;
        var maximumExperience = modelFilter?.MaximumExperience;

        var minimumMaxNumberPlayers = modelFilter?.MinimumMaxNumberPlayers;
        var maximumMaxNumberPlayers = modelFilter?.MaximumMaxNumberPlayers;

        var minimumNumberEmployedPlaces = modelFilter?.MinimumNumberEmployedPlaces;
        var maximumNumberEmployedPlaces = modelFilter?.MinimumNumberEmployedPlaces;

        var currentDate = DateTime.UtcNow;

        var campaigns = _campaignsRepository.GetAll(x =>
            (minimumNumberEmployedPlaces == null || minimumNumberEmployedPlaces < x.NumberEmployedPlaces) &&
            (minimumNumberSessions == null || minimumNumberSessions < x.NumberSessions) &&
            (minimumExperience == null || minimumExperience < x.Experience) &&
            (minimumMaxNumberPlayers == null || minimumMaxNumberPlayers < x.MaxNumberPlayers) &&
            (maximumExperience == null || maximumExperience > x.Experience) &&
            (maximumMaxNumberPlayers == null || maximumMaxNumberPlayers > x.MaxNumberPlayers) &&
            (maximumNumberEmployedPlaces == null || maximumNumberEmployedPlaces > x.NumberEmployedPlaces) &&
            (maximumNumberSessions == null || maximumNumberSessions > x.NumberSessions));
        return _mapper.Map<IEnumerable<CampaignModel>>(campaigns);
    }

    public CampaignModel GetCampaignInfo(Guid campaignId)
    {
        var campaign = _campaignsRepository.GetById(campaignId);
        if (campaign is null)
        {
            throw new ArgumentException("Campaign not found");
        }

        return _mapper.Map<CampaignModel>(campaign);
    }
}