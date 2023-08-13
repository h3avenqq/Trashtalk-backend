using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.UserTrash.Commands.CreateUserTrash;
using Trashtalk.Domain;

namespace Trashtalk.WebAPI.Models
{
    public class CreateUserTrashDto : IMapWith<CreateUserTrashCommand>
    {
        public Guid TrashId { get; set; }
        public Guid UserId { get; set; }
        public GeoPoint Coordinates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserTrashDto,  CreateUserTrashCommand>()
                .ForMember(x=>x.TrashId, opt=>opt.MapFrom(x=>x.TrashId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.Coordinates, opt => opt.MapFrom(x => x.Coordinates));
        }
    }
}
