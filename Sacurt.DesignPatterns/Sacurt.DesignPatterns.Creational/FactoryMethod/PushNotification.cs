namespace Sacurt.DesignPatterns.Creational.FactoryMethod;

public class PushNotification : INotification
{
    public string Channel => "Push";

    public string Send(string recipient, string message)
    {
        return $"Sending Push notification to {recipient}: {message}";
    }
}
