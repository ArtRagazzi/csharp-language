using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment :Payment{
    public BoletoPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, Address address, Document document, Email email, string barCode, string boletoNumber) : base(paidDate, expireDate, total, totalPaid, owner, address, document, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber {get; private set;}

}