using AutoMapper;
using BoardGameCampaign.BL.Keepers.Entities;
using BoardGameCampaign.DataAccess.Entities;

namespace BoardGameCampaign.BL.Mapper;

public class KeepersBLProfile : Profile
{
    public KeepersBLProfile()
    {
        CreateMap<KeeperEntity, KeeperModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
            .ForMember(x => x.Nickname, y => y.MapFrom(src => src.Nickname));

        CreateMap<CreateKeeperModel, KeeperEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}