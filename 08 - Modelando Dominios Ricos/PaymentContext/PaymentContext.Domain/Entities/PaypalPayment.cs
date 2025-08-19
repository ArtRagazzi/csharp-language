using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment:Payment{
    public PayPalPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, Address address, Document document, Email email, string transactionCode) : base(paidDate, expireDate, total, totalPaid, owner, address, document, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode {get; private set; }
}