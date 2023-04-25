using MediatR;
using PatternMediatorWithMediatorR.Domain.Commands.Request;
using PatternMediatorWithMediatorR.Infrastructure.Model;
using PatternMediatorWithMediatorR.Infrastructure.Repository;

namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest>
{

    IRepository<Customer> _repository;

    public DeleteCustomerHandler()
    {
        _repository = new CustomerRepository();
    }
    public Task Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.Id);
        return Task.CompletedTask;
    }
}
