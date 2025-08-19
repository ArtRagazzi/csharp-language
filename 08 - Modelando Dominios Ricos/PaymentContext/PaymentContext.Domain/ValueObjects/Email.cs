using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string address){
        Address = address;

        if (!Validate())
        {
            AddNotification("E-mail invalido");
        }
    }

    public string Address { get; private set; }
    
    
    private bool Validate()
    {
        if (Address.Contains("@"))
        {
            return true;
        }
        return false;
    }
}
