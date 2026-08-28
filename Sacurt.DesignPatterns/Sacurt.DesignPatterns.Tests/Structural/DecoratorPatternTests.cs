using Sacurt.DesignPatterns.Structural.Decorator;

namespace Sacurt.DesignPatterns.Tests.Structural;

public class DecoratorPatternTests
{
    [Fact]
    public void SimpleCoffee_ShouldReturnBaseDescriptionAndCost()
    {
        // Arrange
        ICoffee coffee = new SimpleCoffee();

        // Assert
        Assert.Equal("Simple Coffee", coffee.GetDescription());
        Assert.Equal(5.00m, coffee.GetCost());
    }

    [Fact]
    public void MilkDecorator_ShouldAddMilkBehavior()
    {
        // Arrange
        ICoffee coffee = new MilkDecorator(new SimpleCoffee());

        // Assert
        Assert.Equal("Simple Coffee, Milk", coffee.GetDescription());
        Assert.Equal(6.50m, coffee.GetCost());
    }

    [Fact]
    public void MultipleDecorators_ShouldComposeBehaviorsIncrementally()
    {
        // Arrange
        ICoffee coffee = new SugarDecorator(new MilkDecorator(new SimpleCoffee()));

        // Assert
        Assert.Equal("Simple Coffee, Milk, Sugar", coffee.GetDescription());
        Assert.Equal(7.00m, coffee.GetCost());
    }

    [Fact]
    public void DecoratorsInDifferentOrders_ShouldChangeDescriptionComposition()
    {
        // Arrange
        ICoffee milkThenSugar = new SugarDecorator(new MilkDecorator(new SimpleCoffee()));
        ICoffee sugarThenMilk = new MilkDecorator(new SugarDecorator(new SimpleCoffee()));

        // Assert
        Assert.Equal("Simple Coffee, Milk, Sugar", milkThenSugar.GetDescription());
        Assert.Equal("Simple Coffee, Sugar, Milk", sugarThenMilk.GetDescription());
        Assert.Equal(milkThenSugar.GetCost(), sugarThenMilk.GetCost());
    }

    [Fact]
    public void DecoratingCoffee_ShouldNotModifyOriginalComponent()
    {
        // Arrange
        var simpleCoffee = new SimpleCoffee();
        ICoffee decoratedCoffee = new MilkDecorator(simpleCoffee);

        // Act
        var originalDescription = simpleCoffee.GetDescription();
        var originalCost = simpleCoffee.GetCost();

        // Assert
        Assert.Equal("Simple Coffee", originalDescription);
        Assert.Equal(5.00m, originalCost);
        Assert.Equal("Simple Coffee, Milk", decoratedCoffee.GetDescription());
        Assert.Equal(6.50m, decoratedCoffee.GetCost());
    }
}
