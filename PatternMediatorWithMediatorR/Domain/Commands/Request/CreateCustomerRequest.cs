using MediatR;
using PatternMediatorWithMediatorR.Domain.Commands.Response;

namespace PatternMediatorWithMediatorR.Domain.Commands.Request;

public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}