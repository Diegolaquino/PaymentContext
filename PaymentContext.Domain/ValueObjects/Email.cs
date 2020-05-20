using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            if (string.IsNullOrEmpty(Address))
                AddNotification(nameof(Address), "Email inválido");
        }

        public string Address { get; private set; }
    }
}
