namespace PatternMediatorWithMediatorR.Domain.Commands.Response;

public class UpdateCustomerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateRegister { get; set; }
}
