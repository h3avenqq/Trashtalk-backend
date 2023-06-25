using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeList
{
    public class TrashTypeLookupDto : IMapWith<TrashType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrashType, TrashTypeLookupDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Algorithm, opt => opt.MapFrom(x => x.Algorithm))
                .ForMember(x => x.TrashBinId, opt => opt.MapFrom(x => x.TrashBinId));
        }
    }
}
