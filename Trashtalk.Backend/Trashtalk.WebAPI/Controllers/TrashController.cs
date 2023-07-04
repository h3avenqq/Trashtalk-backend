using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.Trash.Commands.CreateTrash;
using Trashtalk.Application.CQRS.Trash.Commands.DeleteTrash;
using Trashtalk.Application.CQRS.Trash.Commands.UpdateTrash;
using Trashtalk.Application.CQRS.Trash.Queries.GetTrashDetails;
using Trashtalk.Application.CQRS.Trash.Queries.GetTrashList;
using Trashtalk.WebAPI.Models;

namespace Trashtalk.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TrashController : BaseController
    {
        private readonly IMapper _mapper;

        public TrashController(IMapper mapper)
        {
            _mapper = mapper;
        }


        /// <summary>
        /// Gets the list of trash
        /// </summary>
        /// <returns>Returns TrashListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TrashListVm>> GetAll()
        {
            var query = new GetTrashListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the trash by barcode
        /// </summary>
        /// <param name="id">Trash barcode (string)</param>
        /// <returns>Returns TrashDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{barcode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TrashDetailsVm>> Get(string barcode)
        {
            var query = new GetTrashDetailsQuery()
            {
                Barcode = barcode
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the trash
        /// </summary>
        /// <param name="createTrashDto">CreateTrashDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTrashDto createTrashDto)
        {
            var command = _mapper.Map<CreateTrashCommand>(createTrashDto);

            var trashId = await Mediatr.Send(command);

            return Ok(trashId);
        }


        /// <summary>
        /// Updates the trash
        /// </summary>
        /// <param name="updateTrashDto">UpdateTrashDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateTrashDto updateTrashDto)
        {
            var command = _mapper.Map<UpdateTrashCommand>(updateTrashDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the trash by id
        /// </summary>
        /// <param name="id">Id of the trash (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTrashCommand()
            {
                Id = id
            };

            await Mediatr.Send(command);

            return NoContent();
        }
    }
}
