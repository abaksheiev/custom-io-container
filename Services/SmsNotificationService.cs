using CustomIoC.Contracts;

namespace CustomIoC.Services;

public class SmsNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}
