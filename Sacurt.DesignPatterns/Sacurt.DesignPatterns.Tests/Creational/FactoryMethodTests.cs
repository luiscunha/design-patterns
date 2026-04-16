using Sacurt.DesignPatterns.Creational.FactoryMethod;

namespace Sacurt.DesignPatterns.Tests.Creational;

public class FactoryMethodTests
{
    [Fact]
    public void EmailNotificationCreator_ShouldCreateEmailNotification()
    {
        // Arrange
        var creator = new EmailNotificationCreator();

        // Act
        var notification = creator.CreateNotification();

        // Assert
        Assert.IsType<EmailNotification>(notification);
        Assert.Equal("Email", notification.Channel);
    }

    [Fact]
    public void SmsNotificationCreator_ShouldCreateSmsNotification()
    {
        // Arrange
        var creator = new SmsNotificationCreator();

        // Act
        var notification = creator.CreateNotification();

        // Assert
        Assert.IsType<SmsNotification>(notification);
        Assert.Equal("SMS", notification.Channel);
    }

    [Fact]
    public void PushNotificationCreator_ShouldCreatePushNotification()
    {
        // Arrange
        var creator = new PushNotificationCreator();

        // Act
        var notification = creator.CreateNotification();

        // Assert
        Assert.IsType<PushNotification>(notification);
        Assert.Equal("Push", notification.Channel);
    }

    [Fact]
    public void EmailNotificationCreator_NotifyShouldSendEmailMessage()
    {
        // Arrange
        var creator = new EmailNotificationCreator();
        var recipient = "user@mail.com";
        var message = "Hello!";

        // Act
        var result = creator.Notify(recipient, message);

        // Assert
        Assert.Equal("Sending Email to user@mail.com: Hello!", result);
    }

    [Fact]
    public void SmsNotificationCreator_NotifyShouldSendSmsMessage()
    {
        // Arrange
        var creator = new SmsNotificationCreator();
        var recipient = "+1234567890";
        var message = "Hello!";

        // Act
        var result = creator.Notify(recipient, message);

        // Assert
        Assert.Equal("Sending SMS to +1234567890: Hello!", result);
    }

    [Fact]
    public void PushNotificationCreator_NotifyShouldSendPushMessage()
    {
        // Arrange
        var creator = new PushNotificationCreator();
        var recipient = "device-token-123";
        var message = "Hello!";

        // Act
        var result = creator.Notify(recipient, message);

        // Assert
        Assert.Equal("Sending Push notification to device-token-123: Hello!", result);
    }

    [Fact]
    public void AllCreators_ShouldReturnDifferentNotificationTypes()
    {
        // Arrange
        NotificationCreator[] creators =
        [
            new EmailNotificationCreator(),
            new SmsNotificationCreator(),
            new PushNotificationCreator()
        ];

        // Act
        var notifications = creators.Select(c => c.CreateNotification()).ToArray();

        // Assert
        Assert.Equal(3, notifications.Select(n => n.GetType()).Distinct().Count());
        Assert.Equal(3, notifications.Select(n => n.Channel).Distinct().Count());
    }

    [Fact]
    public void Creator_ShouldCreateNewInstanceOnEachCall()
    {
        // Arrange
        var creator = new EmailNotificationCreator();

        // Act
        var notification1 = creator.CreateNotification();
        var notification2 = creator.CreateNotification();

        // Assert
        Assert.NotSame(notification1, notification2);
    }
}
