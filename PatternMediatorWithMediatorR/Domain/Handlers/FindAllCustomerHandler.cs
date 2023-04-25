using MediatR;
using PatternMediatorWithMediatorR.Domain.Queries.Requests;
using PatternMediatorWithMediatorR.Domain.Queries.Responses;
using PatternMediatorWithMediatorR.Infrastructure.Model;
using PatternMediatorWithMediatorR.Infrastructure.Repository;

namespace PatternMediatorWithMediatorR.Domain.Handlers
{
    public class FindAllCustomerHandler : IRequestHandler<FindAllCustomerRequest, FindAllCustomerResponse>
    {
        IRepository<Customer> _repository;

        public FindAllCustomerHandler()
        {
            _repository = new CustomerRepository();
        }

        public async Task<FindAllCustomerResponse> Handle(FindAllCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();

            return new FindAllCustomerResponse() { AllCustomer = result };
        }
    }
}
