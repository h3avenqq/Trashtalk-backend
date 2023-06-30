using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.CQRS.News.Commands.CreateNews;
using Trashtalk.Application.CQRS.News.Commands.UpdateNews;

namespace Trashtalk.WebAPI.Models
{
    public class UpdateNewsDto : IMapWith<UpdateNewsCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsDto, UpdateNewsCommand>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.BriefDescription, opt => opt.MapFrom(x => x.BriefDescription))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId));
        }
    }
}
