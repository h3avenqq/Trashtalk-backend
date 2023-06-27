using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.News.Commands.CreateNews;

namespace Trashtalk.WebAPI.Models
{
    public class CreateNewsDto : IMapWith<Domain.News>
    {
        public string Title { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNewsCommand>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.BriefDescription, opt => opt.MapFrom(x => x.BriefDescription))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId));
        }
    }
}
