namespace Sacurt.DesignPatterns.Structural.Decorator;

public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Simple Coffee";

    public decimal GetCost() => 5.00m;
}
