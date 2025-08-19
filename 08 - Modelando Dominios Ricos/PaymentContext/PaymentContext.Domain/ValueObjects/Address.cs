using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street {get; private set;}
    public int Number {get; private set;}
    public string Neighborhood {get; private set;}
    public string City {get; private set;}
    public string Country { get; private set; }
    public string State {get; private set;}
    public string ZipCode {get; private set;}

    public Address (string street, int number, string neighborhood,  string city, string country, string state, string ZipCode){
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        Country = country;
        State = state;
        ZipCode = ZipCode;
    }


}
