using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }


    public Name (string firstname, string lastname){
        FirstName = firstname;
        LastName = lastname;

        if (!Validate())
        {
            AddNotification("Nome ou Sobrenome invalidos");
        }
        
    }

    private bool Validate()
    {
        if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
        {
            return false;
        }
        return true;
    }
}
