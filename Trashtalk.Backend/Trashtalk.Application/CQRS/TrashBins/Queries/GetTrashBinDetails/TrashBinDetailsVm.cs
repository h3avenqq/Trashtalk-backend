using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinDetails
{
    public class TrashBinDetailsVm : IMapWith<TrashBin>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrashBin, TrashBinDetailsVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => x.Color));
        }
    }
}

