namespace Sacurt.DesignPatterns.Structural.Decorator;

public class MilkDecorator(ICoffee coffee) : CoffeeDecorator(coffee)
{
    public override string GetDescription() => $"{base.GetDescription()}, Milk";

    public override decimal GetCost() => base.GetCost() + 1.50m;
}
