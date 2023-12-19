﻿using AutoMapper;
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

    //void DeleteKeeper(Guid keeperId)
    //entity = repository.GetById() => if null throw exception
    //delete if not null

    //KeeperModel UpdateKeeper(UpdateKeeperModel model) //with Id
    //validate data
    //entity = repository.GetById(id) => if null throw exception
    //entity.FirstName = model.FirstName ...
    //save(entity)
    //return _mapper.Map<KeeperModel>(entity);
}