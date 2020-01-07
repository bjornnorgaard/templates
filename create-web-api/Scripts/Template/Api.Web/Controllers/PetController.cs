using System;
using System.Threading.Tasks;
using Application.Features.[Entity];
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class [Entity]Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public [Entity]Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAll[Entity].Result>> Get([FromQuery] int take = 10, [FromQuery] int skip = 0)
        {
            var command = new GetAll[Entity].Command { Take = take, Skip = skip };
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Get[Entity].Result>> Get(Guid id)
        {
            var command = new Get[Entity].Command { Id = id };

            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Create[Entity].Result>> Post([FromBody] Create[Entity].Command command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Update[Entity].Result>> Post(Guid id, [FromBody] Update[Entity].Command command)
        {
            if (id != command.Id) return BadRequest("Ids not matching");

            var result = await _mediator.Send(command);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Delete[Entity].Result>> Post(Guid id)
        {
            var command = new Delete[Entity].Command { Id = id };

            var result = await _mediator.Send(command);

            return result;
        }
    }
}
