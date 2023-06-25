using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.TrashBins.Commands.UpdateTrashBin;

namespace Trashtalk.WebAPI.Models
{
    public class UpdateTrashBinDto : IMapWith<UpdateTrashBinCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTrashBinDto, UpdateTrashBinCommand>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => x.Color));
        }
    }
}
