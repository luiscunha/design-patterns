using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sacurt.DesignPatterns.Creational.Builder;

public class UserBuilder
{
    private string _name;
    private string _email;
    private AddressBuilder _addressBuilder;

    private UserBuilder() { }

    public static UserBuilder NewUser()
    {
        return new UserBuilder();
    }

    public UserBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public UserBuilder AndEmail(string email)
    {
        _email = email;
        return this;
    }

    public UserBuilder LiveIn(Action<AddressBuilder> action)
    {
        if (_addressBuilder is null)
            _addressBuilder = AddressBuilder.NewAddress();

        action(_addressBuilder);
        return this;
    }

    public User Build()
    {
        return new User()
        {
            Name = _name,
            Email = _email,
            UserAddress = _addressBuilder?.Build()
        };
    }
}

