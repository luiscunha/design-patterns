using Sacurt.DesignPatterns.Creational.Builder;

namespace Sacurt.DesignPatterns.Tests;

public class BuilderPatternTests
{
    [Fact]
    public void UserBuilder_ShouldCreateUserWithoutAddress()
    {
        // Arrange
        var name = "Son Goku";
        var email = "son.goku@mail.com";

        // Act
        var user = UserBuilder.NewUser()
           .WithName(name)
           .AndEmail(email)
           .Build();

        // Assert
        Assert.Equal(name, user.Name);
        Assert.Equal(email, user.Email);
        Assert.Null(user.UserAddress);
    }

    [Fact]
    public void UserBuilder_ShouldCreateUserWithAddress()
    {
        // Arrange
        var name = "Monica Galler";
        var email = "monica.galler@mail.com";
        var street = "Grove Street";
        var number = "495";
        var zipCode = "NY 10014";
        var city = "New York";
        var country = "USA";

        // Act
        var user = UserBuilder.NewUser()
            .WithName(name)
            .AndEmail(email)
            .LiveIn(address => address
                .OnStreet(street)
                .AtNumber(number)
                .WithZipCode(zipCode)
                .InTheCityOf(city)
                .InCountry(country) 
            )
           .Build();

        // Assert
        Assert.Equal(name, user.Name);
        Assert.Equal(email, user.Email);
        Assert.NotNull(user.UserAddress);
        Assert.Equal(street, user.UserAddress.Street);
        Assert.Equal(number, user.UserAddress.Number);
        Assert.Equal(zipCode, user.UserAddress.ZipCode);
        Assert.Equal(city, user.UserAddress.City);
        Assert.Equal(country, user.UserAddress.Country);

    }
}
