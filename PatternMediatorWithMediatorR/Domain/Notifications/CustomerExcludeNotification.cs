namespace PatternMediatorWithMediatorR.Domain.Notifications;

public class CustomerExcludeNotification : INotification
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
