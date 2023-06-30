using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.TrashBins.Commands.CreateTrashBin;
using Trashtalk.Application.CQRS.TrashBins.Commands.DeleteTrashBin;
using Trashtalk.Application.CQRS.TrashBins.Commands.UpdateTrashBin;
using Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinDetails;
using Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinList;
using Trashtalk.WebAPI.Models;

namespace Trashtalk.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TrashBinController : BaseController
    {
        private readonly IMapper _mapper;

        public TrashBinController(IMapper mapper)
        {
            _mapper = mapper;
        }


        /// <summary>
        /// Gets the list of trash bins
        /// </summary>
        /// <returns>Returns TrashBinListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TrashBinListVm>> GetAll()
        {
            var query = new GetTrashBinListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the trash bin by id
        /// </summary>
        /// <param name="id">Trash bin id (guid)</param>
        /// <returns>Returns NewsDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TrashBinDetailsVm>> Get(Guid id)
        {
            var query = new GetTrashBinDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the trash bin
        /// </summary>
        /// <param name="createTrashBinDto">CreateTrashBinDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTrashBinDto createTrashBinDto)
        {
            var command = _mapper.Map<CreateTrashBinCommand>(createTrashBinDto);

            var trashBinId = await Mediatr.Send(command);

            return Ok(trashBinId);
        }

        /// <summary>
        /// Updates the trash bin
        /// </summary>
        /// <param name="updateTrashBinDto">UpdateTrashBinDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateTrashBinDto updateTrashBinDto)
        {
            var command = _mapper.Map<UpdateTrashBinCommand>(updateTrashBinDto);

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
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTrashBinCommand()
            {
                Id = id
            };

            await Mediatr.Send(command);

            return NoContent();
        }
    }
}
