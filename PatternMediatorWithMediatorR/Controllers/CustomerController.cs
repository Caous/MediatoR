using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatternMediatorWithMediatorR.Domain.Commands.Request;
using PatternMediatorWithMediatorR.Domain.Handlers;
using PatternMediatorWithMediatorR.Domain.Queries.Requests;
using System.Text.Json;

namespace PatternMediatorWithMediatorR.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public IActionResult Post([FromBody] CreateCustomerRequest command)
        {
            var response = _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("GetId")]
        public IActionResult Get([FromQuery] FindCustomerByIdRequest command)
        {
            var result = _mediator.Send(command);
            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpPut]
        public IActionResult Put([FromQuery] UpdateCustomerRequest command)
        {
            var result = _mediator.Send(command);
            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteCustomerRequest command)
        {
            if (_mediator.Send(command).IsCompletedSuccessfully)
                return Ok();

            return BadRequest();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] FindAllCustomerRequest command)
        {
            var result = _mediator.Send(command);
            return Ok(JsonSerializer.Serialize(result));
        }
    }
}
