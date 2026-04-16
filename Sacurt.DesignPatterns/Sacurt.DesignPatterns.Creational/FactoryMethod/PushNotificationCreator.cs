namespace Sacurt.DesignPatterns.Creational.FactoryMethod;

public class PushNotificationCreator : NotificationCreator
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}
