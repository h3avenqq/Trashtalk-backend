using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.TrashTypes.Commands.CreateTrashType;
using Trashtalk.Application.CQRS.TrashTypes.Commands.DeleteTrashType;
using Trashtalk.Application.CQRS.TrashTypes.Commands.UpdateTrashType;
using Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeDetails;
using Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeList;
using Trashtalk.WebAPI.Models;

namespace Trashtalk.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TrashTypeController : BaseController
    {
        private readonly IMapper _mapper;

        public TrashTypeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of trash types
        /// </summary>
        /// <returns>Returns TrashTypeListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TrashTypeListVm>> GetAll()
        {
            var query = new GetTrashTypeListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the trash type by id
        /// </summary>
        /// <param name="id">Trash type id (guid)</param>
        /// <returns>Returns TrashTypeDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TrashTypeDetailsVm>> Get(Guid id)
        {
            var query = new GetTrashTypeDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }
        /// <summary>
        /// Creates the trash type
        /// </summary>
        /// <param name="createTrashTypeDto">CreateTrashTypeDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTrashTypeDto createTrashTypeDto)
        {
            var command = _mapper.Map<CreateTrashTypeCommand>(createTrashTypeDto);

            var trashTypeId = await Mediatr.Send(command);

            return Ok(trashTypeId);
        }

        /// <summary>
        /// Updates the trash type
        /// </summary>
        /// <param name="updateTrashTypeDto">UpdateTrashTypeDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateTrashTypeDto updateTrashTypeDto)
        {
            var command = _mapper.Map<UpdateTrashTypeCommand>(updateTrashTypeDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the trash type by id
        /// </summary>
        /// <param name="id">Id of the trash type (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTrashTypeCommand()
            {
                Id = id
            };

            await Mediatr.Send(command);

            return NoContent();
        }
    }
}
