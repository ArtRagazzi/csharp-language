using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentsTests
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var name = new Name("Teste","Teste");
        foreach(var not in name.GetNotifications()){
            Console.WriteLine(not);
        }
        
    }
    
}