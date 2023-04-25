using MediatR;
using PatternMediatorWithMediatorR.Domain.Commands.Request;
using PatternMediatorWithMediatorR.Domain.Commands.Response;
using PatternMediatorWithMediatorR.Infrastructure.Model;
using PatternMediatorWithMediatorR.Infrastructure.Repository;

namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    IRepository<Customer> _repository;

    public CreateCustomerHandler()
    {
        _repository = new CustomerRepository();
    }

    public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        // Aplicar Fail Fast Validations

        // Cria a entidade
        var customer = new Customer(Guid.Empty, request.Name, request.LastName, request.Email);

        // Persiste a entidade no banco
        _repository.Save(customer);

        // Retorna a resposta
        return Task.Run(() => new CreateCustomerResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            DateRegister = customer.DateRegister
        });
    }
}
