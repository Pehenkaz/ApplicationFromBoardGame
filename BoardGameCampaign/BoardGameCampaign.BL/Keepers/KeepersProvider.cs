using AutoMapper;
using BoardGameCampaign.BL.Keepers.Entities;
using BoardGameCampaign.DataAccess;
using BoardGameCampaign.DataAccess.Entities;

namespace BoardGameCampaign.BL.Keepers;

public class KeepersProvider : IKeepersProvider
{
    private readonly IRepository<KeeperEntity> _keeperRepository;
    private readonly IMapper _mapper;

    public KeepersProvider(IRepository<KeeperEntity> keepersRepository, IMapper mapper, int minimumKeeperAge)
    {
        _keeperRepository = keepersRepository;
        _mapper = mapper; 
    }

    public IEnumerable<KeeperModel> GetKeepers(KeepersModelFilter modelFilter = null)
    {
        var minimumAge = modelFilter?.MinAge;
        var maximumAge = modelFilter?.MaxAge;

        var currentDate = DateTime.UtcNow;

        var keepers = _keeperRepository.GetAll(x =>
            (minimumAge == null || x.Age > minimumAge) &&
            (maximumAge == null || x.Age < maximumAge)); 

        return _mapper.Map<IEnumerable<KeeperModel>>(keepers);
    }

    public KeeperModel GetKeeperInfo(Guid keeperId)
    {
        var keeper = _keeperRepository.GetById(keeperId); //return null if not exists
        if (keeper is null)
        {
            throw new ArgumentException("Keeper not found.");
        }

        return _mapper.Map<KeeperModel>(keeper);
    }
}