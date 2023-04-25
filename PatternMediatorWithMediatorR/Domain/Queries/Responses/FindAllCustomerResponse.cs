using PatternMediatorWithMediatorR.Infrastructure.Model;

namespace PatternMediatorWithMediatorR.Domain.Queries.Responses;

public class FindAllCustomerResponse
{
    public IEnumerable<Customer> AllCustomer { get; set; }
}
