using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    class StudentTests
    {
        [TestMethod]
        public void Test()
        {
            var subscription = new Subscription();
            var student = new Student("Diego",  "Aquino", "123456789", "diegol.aquino@gmail.com");

            student.AddSubscription(subscription);
            
        }
    }
}
