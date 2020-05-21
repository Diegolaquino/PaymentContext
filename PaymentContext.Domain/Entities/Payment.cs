﻿using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, string payer, Document document, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Payer = payer;
            Document = document;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "O Total não pode ser zero.")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento.")
                );
        }

        public string Number { get; private set; }

        public DateTime PaidDate { get; private set; }

        public DateTime ExpireDate { get; private set; }

        public decimal Total { get; private set; }

        public decimal TotalPaid { get; private set; }

        public Address Address { get; private set; }

        public string Payer { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }
    }
}
