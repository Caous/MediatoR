namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Customer> _repository;

    public DeleteCustomerHandler(IMediator mediator, IRepository<Customer> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }
    public Task Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.Id);
        _mediator.Publish(new CustomerExcludeNotification() { Id = request.Id});
        return Task.CompletedTask;
    }
}
