namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly IRepository<Customer> _repository;

    public CreateCustomerHandler(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer(Guid.Empty, request.Name, request.LastName, request.Email);

        _repository.Save(customer);

        return Task.Run(() => new CreateCustomerResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            DateRegister = customer.DateRegister
        });
    }
}
