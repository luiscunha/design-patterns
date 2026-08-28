namespace Sacurt.DesignPatterns.Structural.Decorator;

public abstract class CoffeeDecorator(ICoffee coffee) : ICoffee
{
    protected ICoffee Coffee { get; } = coffee;

    public virtual string GetDescription() => Coffee.GetDescription();

    public virtual decimal GetCost() => Coffee.GetCost();
}
