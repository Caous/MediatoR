namespace PatternMediatorWithMediatorR.Domain.Commands.Request;

public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
