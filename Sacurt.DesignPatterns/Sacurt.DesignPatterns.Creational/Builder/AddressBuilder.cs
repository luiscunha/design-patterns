namespace Sacurt.DesignPatterns.Creational.Builder;

public class AddressBuilder
{
    private string _street;
    private string _number;
    private string _zipCode;
    private string _city;
    private string _country;

    private AddressBuilder() { }

    public static AddressBuilder NewAddress() => new();

    public AddressBuilder OnStreet(string street)
    {
        _street = street;
        return this;
    }
    public AddressBuilder AtNumber(string number)
    {
        _number = number;
        return this;
    }
    public AddressBuilder WithZipCode(string zipCode)
    {
        _zipCode = zipCode;
        return this;
    }
    public AddressBuilder InTheCityOf(string city)
    {
        _city = city;
        return this;
    }
    public AddressBuilder InCountry(string country)
    {
        _country = country;
        return this;
    }

    public Address Build()
    {
        return new Address()
        {
            Street = _street,
            Number = _number,
            ZipCode = _zipCode,
            City = _city,
            Country = _country
        };
    }
}

