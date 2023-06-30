using AutoMapper;
using System;
using NetTopologySuite.Geometries;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointDetails
{
    public class ReceptionPointDetailsVm : IMapWith<ReceptionPoint>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public GeoPoint Coordinates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReceptionPoint, ReceptionPointDetailsVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address))
                .ForMember(x => x.Coordinates, opt => opt.MapFrom(x 
                    => new GeoPoint() { X = x.Coordinates.X, Y = x.Coordinates.Y }));
        }
    }

}
