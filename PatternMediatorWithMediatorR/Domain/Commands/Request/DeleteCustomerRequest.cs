using MediatR;

namespace PatternMediatorWithMediatorR.Domain.Commands.Request;

public class DeleteCustomerRequest : IRequest
{
    public Guid Id { get; set; }
}
