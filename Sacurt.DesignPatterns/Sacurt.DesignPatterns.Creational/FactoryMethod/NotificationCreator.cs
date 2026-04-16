namespace Sacurt.DesignPatterns.Creational.FactoryMethod;

public abstract class NotificationCreator
{
    public abstract INotification CreateNotification();

    public string Notify(string recipient, string message)
    {
        var notification = CreateNotification();
        return notification.Send(recipient, message);
    }
}
