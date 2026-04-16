namespace Sacurt.DesignPatterns.Creational.FactoryMethod;

public interface INotification
{
    string Channel { get; }
    string Send(string recipient, string message);
}
