using AutoMapper;
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
    [Route("api/[controller]")]
    public class TrashBinController : BaseController
    {
        private readonly IMapper _mapper;

        public TrashBinController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TrashBinListVm>> GetAll()
        {
            var query = new GetTrashBinListQuery();

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrashBinDetailsVm>> Get(Guid id)
        {
            var query = new GetTrashBinDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediatr.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTrashBinDto createTrashBinDto)
        {
            var command = _mapper.Map<CreateTrashBinCommand>(createTrashBinDto);

            var trashBinId = await Mediatr.Send(command);

            return Ok(trashBinId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTrashBinDto updateTrashBinDto)
        {
            var command = _mapper.Map<UpdateTrashBinCommand>(updateTrashBinDto);

            await Mediatr.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
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
