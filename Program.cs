using CustomIoC.IoC;
using CustomIoC.Contracts;
using CustomIoC.Services;
namespace CustomIoC;

class Program
{
    static void Main(string[] args)
    {
        // Create the IoC container
        var container = new SimpleIoCContainer();

        // Register services
        container.Register<INotificationService, EmailNotificationService>();
        container.Register<NotificationManager>();


        // Resolve and use the NotificationManager
        var manager = container.Resolve<NotificationManager>();
        manager.Notify("Hello, World!");


        container.RegisterSingleton<SettingsManager, SettingsManager>();
         var settings = container.Resolve<SettingsManager>();
         settings.WriteHello();

        var settings2 = container.Resolve<SettingsManager>();
        settings2.WriteHello();
    }
}

