using MediatR;
using PatternMediatorWithMediatorR.Domain.Queries.Requests;
using PatternMediatorWithMediatorR.Domain.Queries.Responses;
using PatternMediatorWithMediatorR.Infrastructure.Model;
using PatternMediatorWithMediatorR.Infrastructure.Repository;

namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class FindCustomerByIdHandler : IRequestHandler<FindCustomerByIdRequest, FindCustomerByIdResponse>
{
    IRepository<Customer> _repository;

    public FindCustomerByIdHandler()
    {
        _repository = new CustomerRepository();
    }

    public async Task<FindCustomerByIdResponse> Handle(FindCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.Get(request.Id);

        return await Task.Run(() => new FindCustomerByIdResponse
        {
            DateRegister = result.DateRegister,
            Email = result.Email,
            Id = result.Id,
            LastName = result.LastName,
            Name = result.Name
        });
    }
}
