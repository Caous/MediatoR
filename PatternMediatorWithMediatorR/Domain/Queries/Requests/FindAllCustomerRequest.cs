using MediatR;
using PatternMediatorWithMediatorR.Domain.Queries.Responses;

namespace PatternMediatorWithMediatorR.Domain.Queries.Requests
{
    public class FindAllCustomerRequest : IRequest<FindAllCustomerResponse>
    {
    }
}
