using AutoMapper;
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
    [Route("api/[controller]")]
    public class ReceptionPointController : BaseController
    {
        private readonly IMapper _mapper;

        public ReceptionPointController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ReceptionPointListVm>> GetAll()
        {
            var query = new GetReceptionPointListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReceptionPointDto createReceptionPointDto)
        {
            var command = _mapper.Map<CreateReceptionPointCommand>(createReceptionPointDto);

            var receptionPointId = await Mediatr.Send(command);

            return Ok(receptionPointId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateReceptionPointDto updateReceptionPointDto)
        {
            var command = _mapper.Map<UpdateReceptionPointCommand>(updateReceptionPointDto);

            await Mediatr.Send(command);

            return NoContent();
        }

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
