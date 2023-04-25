using MediatR;
using PatternMediatorWithMediatorR.Domain.Commands.Request;
using PatternMediatorWithMediatorR.Domain.Commands.Response;
using PatternMediatorWithMediatorR.Infrastructure.Model;
using PatternMediatorWithMediatorR.Infrastructure.Repository;

namespace PatternMediatorWithMediatorR.Domain.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        IRepository<Customer> _repository;

        public UpdateCustomerHandler()
        {
            _repository = new CustomerRepository();
        }

        public Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
          
            var customer = new Customer(request.Id, request.Name, request.LastName, request.Email);

            _repository.Edit(customer);

            return Task.Run(() => new UpdateCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                DateRegister = customer.DateRegister
            });
        }
    }
}
