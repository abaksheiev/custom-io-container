using CustomIoC.Contracts;

namespace CustomIoC.Services;

public class EmailNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}
