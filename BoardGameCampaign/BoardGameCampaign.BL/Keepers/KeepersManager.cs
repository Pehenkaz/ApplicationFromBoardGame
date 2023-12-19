using AutoMapper;
using BoardGameCampaign.BL.Keepers.Entities;
using BoardGameCampaign.DataAccess;
using BoardGameCampaign.DataAccess.Entities;

namespace BoardGameCampaign.BL.Keepers;

public class KeepersManager : IKeepersManager
{
    private readonly IRepository<KeeperEntity> _keepersRepository;
    private readonly IMapper _mapper;

    public KeepersManager(IRepository<KeeperEntity> keepersRepository, IMapper mapper)
    {
        _keepersRepository = keepersRepository;
        _mapper = mapper;
    }

    public KeeperModel CreateKeeper(CreateKeeperModel model)
    {
        if (model.Age < 16)
        {
            throw new ArgumentException("Age must be greater than 16.");
        }

        var entity = _mapper.Map<KeeperEntity>(model);

        _keepersRepository.Save(entity); //id, modification, externalId

        return _mapper.Map<KeeperModel>(entity);
    }

    public void DeleteKeeper(Guid keeperId)
    {
        var entity = _keepersRepository.GetById(keeperId) ?? throw new Exception("Keeper not found");
        _keepersRepository.Delete(entity);
    }

    public KeeperModel UpdateKeeper(Guid keeperId, CreateKeeperModel model)
    {
        //validate data
        var entity = _keepersRepository.GetById(keeperId) ?? throw new Exception("Keeper not found");
        entity.Age = model.Age;
        entity.Nickname = model.Nickname;
        entity.FirstName = model.FirstName;
        entity.SecondName = model.SecondName;
        entity.Patronymic = model.Patronymic;
        _keepersRepository.Save(entity);
        return _mapper.Map<KeeperModel>(entity);
    }
}