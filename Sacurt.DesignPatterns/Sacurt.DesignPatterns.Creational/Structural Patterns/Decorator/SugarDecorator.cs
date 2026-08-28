namespace Sacurt.DesignPatterns.Structural.Decorator;

public class SugarDecorator(ICoffee coffee) : CoffeeDecorator(coffee)
{
    public override string GetDescription() => $"{base.GetDescription()}, Sugar";

    public override decimal GetCost() => base.GetCost() + 0.50m;
}
