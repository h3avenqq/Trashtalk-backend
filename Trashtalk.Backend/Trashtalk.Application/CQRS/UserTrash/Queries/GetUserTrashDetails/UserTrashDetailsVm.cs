using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashDetails
{
    public class UserTrashDetailsVm : IMapWith<Domain.UserTrash>
    {
        public Guid Id { get; set; }
        public Guid TrashId { get; set; }
        public Guid UserId { get; set; }
        public GeoPoint Coordinates { get; set; }
        public DateTime Time { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.UserTrash, UserTrashDetailsVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.TrashId, opt => opt.MapFrom(x => x.TrashId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x=>x.Coordinates, opt=>opt.MapFrom(x=>x.Coordinates))
                .ForMember(x => x.Time, opt => opt.MapFrom(x => x.Time));
        }
    }
}
