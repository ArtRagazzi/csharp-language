using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }


    public Name (string firstname, string lastname){
        FirstName = firstname;
        LastName = lastname;

        if(string.IsNullOrEmpty(FirstName)){
            AddNotification("Nome Invalido");
        }
    }
}
