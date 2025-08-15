using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentsTests
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var subscription = new Subscription(null);
        var student = new Student(firstName: "Artur",  lastName: "Oliveira", document: "12345678", email:"artur@teste.com");
       
        //ERRADO -> student.Subscriptions.Add(subscription);
        student.AddSubscription(subscription);
    }
    
}