using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashList
{
    public class TrashLookupDto : IMapWith<Trash>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public float Weight { get; set; }
        public Guid TypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Trash, TrashLookupDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Barcode, opt => opt.MapFrom(x => x.Barcode))
                .ForMember(x => x.Weight, opt => opt.MapFrom(x => x.Weight))
                .ForMember(x => x.TypeId, opt => opt.MapFrom(x => x.TypeId));
        }
    }
}
