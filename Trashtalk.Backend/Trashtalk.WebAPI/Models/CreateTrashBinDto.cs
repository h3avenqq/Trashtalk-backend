using AutoMapper;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.TrashBins.Commands.CreateTrashBin;

namespace Trashtalk.WebAPI.Models
{
    public class CreateTrashBinDto : IMapWith<CreateTrashBinCommand>
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTrashBinDto, CreateTrashBinCommand>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => x.Color));
        }
    }
}
