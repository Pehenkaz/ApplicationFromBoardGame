using AutoMapper;
using BoardGameCampaign.BL.Campaign.Entities;
using BoardGameCampaign.DataAccess;
using BoardGameCampaign.DataAccess.Entities;

namespace BoardGameCampaign.BL.Campaign;

public class CampaignsManager : ICampaignsManager
{
    private readonly IRepository<CampaignEntity> _campaignsRepository;
    private readonly IMapper _mapper;

    public CampaignsManager(IRepository<CampaignEntity> keepersRepository, IMapper mapper)
    {
        _campaignsRepository = keepersRepository;
        _mapper = mapper;
    }

    public CampaignModel CreateCampaign(CreateCampaignModel model)
    {
        if (model.NumberSessions > 0 && model.MaxNumberPlayers >0)
        {
            throw new ArgumentException("Number sessions and maximum number players must be > 0");
        }

        var entity = _mapper.Map<CampaignEntity>(model);

        _campaignsRepository.Save(entity); //id, modification, externalId

        return _mapper.Map<CampaignModel>(entity);
    }

    public void DeleteCampaign(Guid campaignId)
    {
        var entity = _campaignsRepository.GetById(campaignId) ?? throw new Exception("Campaign not found");
        _campaignsRepository.Delete(entity);
    }

    public CampaignModel UpdateCampaign(Guid campaignId, CreateCampaignModel model)
    {
        //validate data
        var entity = _campaignsRepository.GetById(campaignId) ?? throw new Exception("Campaign not found");
        entity.Genre = model.Genre;
        entity.MaxNumberPlayers = model.MaxNumberPlayers;
        entity.NumberEmployedPlaces = model.NumberEmployedPlaces;
        entity.NumberSessions = model.NumberSessions;
        entity.Experience = model.Experience;
        entity.Keeper = model.Keeper;
        entity.Game = model.Game;
        _campaignsRepository.Save(entity);
        return _mapper.Map<CampaignModel>(entity);
    }
}