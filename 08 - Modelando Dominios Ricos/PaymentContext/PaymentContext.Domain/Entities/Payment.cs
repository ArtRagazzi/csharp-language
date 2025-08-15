namespace PaymentContext.Domain.Entities;

public abstract class Payment{
    protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, string address, string document, string email)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,10).ToUpper();
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Owner = owner;
        Address = address;
        Document = document;
        Email = email;
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set;}
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Owner { get; private set; }
    public string Address { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }

}





