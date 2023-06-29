using AutoMapper;
using NetTopologySuite.Geometries;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.ReceptionPoints.Commands.UpdateReceptionPoint;

namespace Trashtalk.WebAPI.Models
{
    public class UpdateReceptionPointDto : IMapWith<UpdateReceptionPointCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public GeoPoint Coordinates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateReceptionPointDto, UpdateReceptionPointCommand>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address))
                .ForMember(x => x.Coordinates, opt => opt.MapFrom(x => x.Coordinates));
        }
    }
}
