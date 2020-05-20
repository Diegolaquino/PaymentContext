using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscription;

        public Student(Name name, string document, Email email)
        {
            Name = Name;
            Document = document;
            Email = email;
        }

        public Name Name { get; private set; }

        public string Document { get; private set; }

        public Email Email { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            foreach (var sub in Subscriptions)
                sub.Inactivate();

            _subscription.Add(subscription);
        }

        
    }
}
