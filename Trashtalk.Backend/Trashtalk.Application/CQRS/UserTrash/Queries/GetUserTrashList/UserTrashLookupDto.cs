using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashList
{
    public class UserTrashLookupDto : IMapWith<Domain.UserTrash>
    {
        public Guid Id { get; set; }
        public Guid TrashId { get; set; }
        public DateTime Time { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.UserTrash, UserTrashLookupDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.TrashId, opt => opt.MapFrom(x => x.TrashId))
                .ForMember(x => x.Time, opt => opt.MapFrom(x => x.Time));
        }
    }
}
