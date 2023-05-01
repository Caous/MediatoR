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
            try
            {
                _mediator.Publish(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] FindAllCustomerRequest command)
        {
            var result = _mediator.Send(command);
            return Ok(JsonSerializer.Serialize(result));
        }
    }
}
