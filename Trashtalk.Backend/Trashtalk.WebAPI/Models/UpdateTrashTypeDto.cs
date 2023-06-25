using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.TrashTypes.Commands.UpdateTrashType;

namespace Trashtalk.WebAPI.Models
{
    public class UpdateTrashTypeDto : IMapWith<UpdateTrashTypeCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTrashTypeDto, UpdateTrashTypeCommand>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Algorithm, opt => opt.MapFrom(x => x.Algorithm))
                .ForMember(x => x.Algorithm, opt => opt.MapFrom(x => x.Algorithm));
        }
    }
}
