using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.ReceptionPoints.Commands.CreateReceptionPoint;
using Trashtalk.Application.CQRS.ReceptionPoints.Commands.DeleteReceptionPoint;
using Trashtalk.Application.CQRS.ReceptionPoints.Commands.UpdateReceptionPoint;
using Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointDetails;
using Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointList;
using Trashtalk.WebAPI.Models;

namespace Trashtalk.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReceptionPointController : BaseController
    {
        private readonly IMapper _mapper;

        public ReceptionPointController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of reception points
        /// </summary>
        /// <returns>Returns ReceptionPointListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ReceptionPointListVm>> GetAll()
        {
            var query = new GetReceptionPointListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the reception point by id
        /// </summary>
        /// <param name="id">News id (guid)</param>
        /// <returns>Returns ReceptionPointDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceptionPointDetailsVm>> Get(Guid id)
        {
            var query = new GetReceptionPointDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }


        /// <summary>
        /// Creates the reception point
        /// </summary>
        /// <param name="createReceptionPointDto">CreateReceptionPointDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReceptionPointDto createReceptionPointDto)
        {
            var command = _mapper.Map<CreateReceptionPointCommand>(createReceptionPointDto);

            var receptionPointId = await Mediatr.Send(command);

            return Ok(receptionPointId);
        }

        /// <summary>
        /// Updates the reception point
        /// </summary>
        /// <param name="updateReceptionPointDto">UpdateReceptionPointDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateReceptionPointDto updateReceptionPointDto)
        {
            var command = _mapper.Map<UpdateReceptionPointCommand>(updateReceptionPointDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the reception point by id
        /// </summary>
        /// <param name="id">Id of the reception point (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteReceptionPointCommand()
            {
                Id = id
            };

            await Mediatr.Send(command);

            return NoContent();
        }
    }
}
