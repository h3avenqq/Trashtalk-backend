using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.Trash.Commands.CreateTrash;
using Trashtalk.Application.CQRS.Trash.Commands.DeleteTrash;
using Trashtalk.Application.CQRS.Trash.Commands.UpdateTrash;
using Trashtalk.Application.CQRS.Trash.Queries.GetTrashDetails;
using Trashtalk.Application.CQRS.Trash.Queries.GetTrashList;
using Trashtalk.WebAPI.Models;

namespace Trashtalk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TrashController : BaseController
    {
        private readonly IMapper _mapper;

        public TrashController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TrashListVm>> GetAll()
        {
            var query = new GetTrashListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrashDetailsVm>> Get(Guid id)
        {
            var query = new GetTrashDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTrashDto createTrashDto)
        {
            var command = _mapper.Map<CreateTrashCommand>(createTrashDto);

            var trashId = await Mediatr.Send(command);

            return Ok(trashId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTrashDto updateTrashDto)
        {
            var command = _mapper.Map<UpdateTrashCommand>(updateTrashDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
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
