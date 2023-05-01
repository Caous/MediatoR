namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class FindCustomerByIdHandler : IRequestHandler<FindCustomerByIdRequest, FindCustomerByIdResponse>
{
    IRepository<Customer> _repository;

    public FindCustomerByIdHandler(IRepository<Customer> repository)
    {
        _repository = repository;
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
