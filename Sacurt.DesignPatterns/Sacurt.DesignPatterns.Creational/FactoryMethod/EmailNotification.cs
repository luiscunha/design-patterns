namespace Sacurt.DesignPatterns.Creational.FactoryMethod;

public class EmailNotification : INotification
{
    public string Channel => "Email";

    public string Send(string recipient, string message)
    {
        return $"Sending Email to {recipient}: {message}";
    }
}
