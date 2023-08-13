using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.UserTrash.Commands.CreateUserTrash;
using Trashtalk.Application.CQRS.UserTrash.Commands.DeleteUserTrash;
using Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashDetails;
using Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashList;
using Trashtalk.WebAPI.Models;

namespace Trashtalk.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserTrashController : BaseController
    {
        private readonly IMapper _mapper;

        public UserTrashController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of user`s trash
        /// </summary>
        ///  <param name="userId">User id (guid)</param>
        /// <returns>Returns UserTrashListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserTrashListVm>> GetAll(Guid userId)
        {
            var query = new GetUserTrashListQuery()
            {
                UserId = userId
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the user trash by id
        /// </summary>
        /// <param name="id">User trash id (guid)</param>
        /// <param name="userId">User id (guid)</param>
        /// <returns>Returns TrashTypeDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserTrashDetailsVm>> GetAll(Guid id, Guid userId)
        {
            var query = new GetUserTrashDetailsQuery()
            {
                Id = id,
                UserId = userId
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the user trash
        /// </summary>
        /// <param name="createUserTrashDto">CreateUserTrashDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserTrashDto createUserTrashDto)
        {
            var command = _mapper.Map<CreateUserTrashCommand>(createUserTrashDto);

            var userTrashId = await Mediatr.Send(command);

            return Ok(userTrashId);
        }

        /// <summary>
        /// Deletes the user trash by id and userId
        /// </summary>
        /// <param name="id">Id of the user trash (guid)</param>
        /// <param name="userId">user id of the user trash (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id, Guid userId)
        {
            var command = new DeleteUserTrashCommand()
            {
                Id = id,
                UserId = userId
            };

            await Mediatr.Send(command);

            return NoContent();
        }
    }
}
