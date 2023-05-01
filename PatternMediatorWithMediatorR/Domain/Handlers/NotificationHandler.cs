namespace PatternMediatorWithMediatorR.Domain.Handlers;

public class NotificationHandler : INotificationHandler<CustomerExcludeNotification>
{
    public Task Handle(CustomerExcludeNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Exclude success: '{notification.Id} - {notification.Name}'");
        });
    }
}
