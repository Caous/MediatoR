namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class FindAllCustomerHandler : IRequestHandler<FindAllCustomerRequest, FindAllCustomerResponse>
{
    IRepository<Customer> _repository;

    public FindAllCustomerHandler(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<FindAllCustomerResponse> Handle(FindAllCustomerRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll();

        return new FindAllCustomerResponse() { AllCustomer = result };
    }
}
