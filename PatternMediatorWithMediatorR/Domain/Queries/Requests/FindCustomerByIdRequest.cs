namespace PatternMediatorWithMediatorR.Domain.Queries.Requests;

public class FindCustomerByIdRequest  : IRequest<FindCustomerByIdResponse>
{
    public Guid Id { get; set; }
}
