using AutoMapper;
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
    [Route("api/[controller]")]
    public class TrashTypeController : BaseController
    {
        private readonly IMapper _mapper;

        public TrashTypeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TrashTypeListVm>> GetAll()
        {
            var query = new GetTrashTypeListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrashTypeDetailsVm>> Get(Guid id)
        {
            var query = new GetTrashTypeDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTrashTypeDto createTrashTypeDto)
        {
            var command = _mapper.Map<CreateTrashTypeCommand>(createTrashTypeDto);

            var trashTypeId = await Mediatr.Send(command);

            return Ok(trashTypeId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTrashTypeDto updateTrashTypeDto)
        {
            var command = _mapper.Map<UpdateTrashTypeCommand>(updateTrashTypeDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
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
