using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;

        public StudentTests()
        {
            _name = new Name("Diego", "Aquino");
            _document = new Document("12960405772", EDocumentType.CPF);
            _email = new Email("diegol.aquino@gmail.com");
            _address = new Address("Rua são fernando", "218", "Cascadura", "Rio de Janeiro", "Rio de Janeiro", "Brasil", "21311220");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("123-123-123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address,"Diego Corp", _document , _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
        
        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("123-123-123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, "Diego Corp", _document, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}
