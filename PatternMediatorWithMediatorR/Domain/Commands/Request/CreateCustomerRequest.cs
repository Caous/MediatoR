namespace PatternMediatorWithMediatorR.Domain.Commands.Request;

public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}