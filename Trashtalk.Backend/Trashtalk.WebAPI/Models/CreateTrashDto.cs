using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.Trash.Commands.CreateTrash;

namespace Trashtalk.WebAPI.Models
{
    public class CreateTrashDto : IMapWith<CreateTrashCommand>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int Weight { get; set; }
        public Guid TypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTrashDto, CreateTrashCommand>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Barcode, opt => opt.MapFrom(x => x.Barcode))
                .ForMember(x=>x.Weight, opt=>opt.MapFrom(x=>x.Weight))
                .ForMember(x => x.TypeId, opt => opt.MapFrom(x => x.TypeId));
        }
    }
}
