namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest>
{

    IRepository<Customer> _repository;

    public DeleteCustomerHandler(IRepository<Customer> repository)
    {
        _repository = repository;
    }
    public Task Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.Id);
        return Task.CompletedTask;
    }
}
