using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacurt.DesignPatterns.Creational.Builder
{
    public sealed class Address
    {
        public string Street { get; init; }
        public string Number { get; init; }
        public string ZipCode { get; init; } 
        public string City { get; init; } 
        public string Country { get; init; }    
    }
}
