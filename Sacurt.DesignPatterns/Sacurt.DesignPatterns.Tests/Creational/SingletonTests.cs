using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sacurt.DesignPatterns.Creational.Singletons;

namespace Sacurt.DesignPatterns.Tests.Creational;

public class SingletonTests
{
    public SingletonTests()
    {
        // Run some code before each unit test
        LazySingleton.Instance.Reset();
    }

    [Fact]
    public void LazySingleton_ShouldCreateOnlyOneInstance()
    {
        // Arrange
        var instance1 = LazySingleton.Instance;
        var instance2 = LazySingleton.Instance;

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void LazySingleton_ShouldEnsureCounterIncrementOnConcurrency()
    {
        // Arrange  
        var rounds = 100;

        // Act
        Parallel.For(0, rounds, i => LazySingleton.Instance.IncrementCounter());

        // Assert
        Assert.Equal(rounds, LazySingleton.Instance.GetCounter());
    }

    [Fact]
    public async Task LazySingleton_ShouldEnsureCounterIsRightOnConcurrencyVolatileValue()
    {
        // Arrange  
        var rounds = 20;
        var incrementedTimes = 16;
        var decrementedTimes = 4;
        var tasks = new Task[rounds];

        // Act
        for (int i = 0; i < rounds; i++)
        {
            var indexCapturedContext = i;
            tasks[i] = Task.Run(() =>
            {
                if (indexCapturedContext % 5 == 0)
                    LazySingleton.Instance.DecrementCounter();
                else
                    LazySingleton.Instance.IncrementCounter();
            });
        }

        await Task.WhenAll(tasks);

        // Assert
        Assert.Equal(incrementedTimes - decrementedTimes, LazySingleton.Instance.GetCounter());
    }

    [Fact]
    public async Task LazySingleton_ShouldBeThreadSafeUnderHighConcurrency()
    {
        // Arrange
        var rounds = 1000;
        var tasks = new Task[rounds];

        // Act
        for (int i = 0; i < rounds; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                var instance = LazySingleton.Instance;
                instance.IncrementCounter();
            });
        }

        await Task.WhenAll(tasks);

        // Assert
        Assert.Equal(rounds, LazySingleton.Instance.GetCounter());
    }
}

