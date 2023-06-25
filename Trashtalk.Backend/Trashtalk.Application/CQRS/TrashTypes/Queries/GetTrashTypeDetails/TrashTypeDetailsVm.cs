using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeDetails
{
    public class TrashTypeDetailsVm : IMapWith<TrashType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrashType, TrashTypeDetailsVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Algorithm, opt => opt.MapFrom(x => x.Algorithm))
                .ForMember(x => x.TrashBinId, opt => opt.MapFrom(x => x.TrashBinId));
        }
    }
}
