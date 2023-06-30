using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.News.Commands.CreateNews;
using Trashtalk.Application.CQRS.News.Commands.DeleteNews;
using Trashtalk.Application.CQRS.News.Commands.UpdateNews;
using Trashtalk.Application.CQRS.News.Queries.GetNewsDetails;
using Trashtalk.Application.CQRS.News.Queries.GetNewsList;
using Trashtalk.WebAPI.Models;

namespace Trashtalk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        private readonly IMapper _mapper;

        public NewsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<NewsListVm>> GetAll()
        {
            var query = new GetNewsListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDetailsVm>> Get(Guid id)
        {
            var query = new GetNewsDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsDto createNewsDto)
        {
            var command = _mapper.Map<CreateNewsCommand>(createNewsDto);

            var newsId = await Mediatr.Send(command);

            return Ok(newsId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateNewsDto updateNewsDto)
        {
            var command = _mapper.Map<UpdateNewsCommand>(updateNewsDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteNewsCommand() 
            { 
                Id = id 
            };

            await Mediatr.Send(command);

            return NoContent();
        }
    }
}
