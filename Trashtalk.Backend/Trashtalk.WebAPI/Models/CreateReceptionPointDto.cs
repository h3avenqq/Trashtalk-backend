using AutoMapper;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.ReceptionPoints.Commands.CreateReceptionPoint;

namespace Trashtalk.WebAPI.Models
{
    public class CreateReceptionPointDto : IMapWith<CreateReceptionPointCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public GeoPoint Coordinates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReceptionPointDto, CreateReceptionPointCommand>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address))
                .ForMember(x => x.Coordinates, 
                    opt => opt.MapFrom(x => 
                        new NetTopologySuite.Geometries.Point(x.Coordinates.X, x.Coordinates.Y) { SRID = 4326 }));
        }
    }
}
