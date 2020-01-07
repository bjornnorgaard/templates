using System;
using System.Threading.Tasks;
using Application.Features.Pet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllPet.Result>> Get([FromQuery] int take = 10, [FromQuery] int skip = 0)
        {
            var command = new GetAllPet.Command { Take = take, Skip = skip };
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPet.Result>> Get(Guid id)
        {
            var command = new GetPet.Command { Id = id };

            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<CreatePet.Result>> Post([FromBody] CreatePet.Command command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePet.Result>> Post(Guid id, [FromBody] UpdatePet.Command command)
        {
            if (id != command.Id) return BadRequest("Ids not matching");

            var result = await _mediator.Send(command);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletePet.Result>> Post(Guid id)
        {
            var command = new DeletePet.Command { Id = id };

            var result = await _mediator.Send(command);

            return result;
        }
    }
}
