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

    public Address (string street, int number, string neighborhood,  string city, string country, string state, string zipCode){
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        Country = country;
        State = state;
        ZipCode = zipCode;

        if (!Validate())
        {
            AddNotification("Endereço invalido");
        }
    }
    
    
    private bool Validate()
    {
        if (string.IsNullOrEmpty(Street) || string.IsNullOrEmpty(City))
        {
            return false;
        }
        return true;
    }


}
