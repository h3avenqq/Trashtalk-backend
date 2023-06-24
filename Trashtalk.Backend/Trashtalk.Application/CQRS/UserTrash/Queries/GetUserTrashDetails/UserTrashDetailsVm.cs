using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashDetails
{
    public class UserTrashDetailsVm : IMapWith<Domain.UserTrash>
    {
        public Guid Id { get; set; }
        public Guid TrashId { get; set; }
        public Guid UserId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime Time { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.UserTrash, UserTrashDetailsVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.TrashId, opt => opt.MapFrom(x => x.TrashId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country))
                .ForMember(x => x.Region, opt => opt.MapFrom(x => x.Region))
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.City))
                .ForMember(x => x.District, opt => opt.MapFrom(x => x.District))
                .ForMember(x => x.Time, opt => opt.MapFrom(x => x.Time));
        }
    }
}
