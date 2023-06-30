using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        private readonly IMapper _mapper;

        public NewsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of news
        /// </summary>
        /// <returns>Returns NewsListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NewsListVm>> GetAll()
        {
            var query = new GetNewsListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the news by id
        /// </summary>
        /// <param name="id">News id (guid)</param>
        /// <returns>Returns NewsDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NewsDetailsVm>> Get(Guid id)
        {
            var query = new GetNewsDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the news
        /// </summary>
        /// <param name="createNewsDto">CreateNewsDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsDto createNewsDto)
        {
            var command = _mapper.Map<CreateNewsCommand>(createNewsDto);

            var newsId = await Mediatr.Send(command);

            return Ok(newsId);
        }


        /// <summary>
        /// Updates the news
        /// </summary>
        /// <param name="updateNewsDto">UpdateNewsDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateNewsDto updateNewsDto)
        {
            var command = _mapper.Map<UpdateNewsCommand>(updateNewsDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the news by id
        /// </summary>
        /// <param name="id">Id of the news (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
