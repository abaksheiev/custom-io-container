using CustomIoC.Contracts;

namespace CustomIoC;

public class NotificationManager
{
    private readonly INotificationService _notificationService;

   
    public NotificationManager(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void Notify(string message)
    {
        _notificationService.Send(message);
    }
}