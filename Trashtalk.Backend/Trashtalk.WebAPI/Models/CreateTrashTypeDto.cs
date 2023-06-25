using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.TrashTypes.Commands.CreateTrashType;

namespace Trashtalk.WebAPI.Models
{
    public class CreateTrashTypeDto : IMapWith<CreateTrashTypeCommand>
    {
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTrashTypeDto, CreateTrashTypeCommand>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Algorithm, opt => opt.MapFrom(x => x.Algorithm))
                .ForMember(x => x.Algorithm, opt => opt.MapFrom(x => x.Algorithm));
        }
    }
}
