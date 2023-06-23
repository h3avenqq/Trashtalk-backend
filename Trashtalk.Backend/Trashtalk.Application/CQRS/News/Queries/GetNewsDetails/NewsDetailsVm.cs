using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;

namespace Trashtalk.Application.CQRS.News.Queries.GetNewsDetails
{
    public class NewsDetailsVm : IMapWith<Domain.News>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? EditDate { get; set; }
        public Guid AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.News, NewsDetailsVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.BriefDescription, opt => opt.MapFrom(x => x.BriefDescription))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.PublishDate, opt => opt.MapFrom(x => x.PublishDate))
                .ForMember(x => x.EditDate, opt => opt.MapFrom(x => x.EditDate))
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId));
        }
    }
}
