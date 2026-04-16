namespace Sacurt.DesignPatterns.Creational.FactoryMethod;

public class SmsNotification : INotification
{
    public string Channel => "SMS";

    public string Send(string recipient, string message)
    {
        return $"Sending SMS to {recipient}: {message}";
    }
}
