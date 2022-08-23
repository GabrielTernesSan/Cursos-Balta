using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("Gabriel", "Santos", "12345678910", "santos.tgabriel@gmail.com");
            //student.FirstName = "";
            //student.Subscriptions.Add(subscription); Tá errado porque não "cancela" a outra subscription
            student.AddSubscription(subscription);
        }
    }
}