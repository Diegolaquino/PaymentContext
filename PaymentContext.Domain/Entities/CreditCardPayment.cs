﻿using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, string cardNumber, string lastTransactionNumer, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, 
            string address, string owner, string document, string email) : base(paidDate, expireDate, total, totalPaid, address, owner, document, email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumer = lastTransactionNumer;
        }

        public string CardHolderName { get; private set; }

        public string CardNumber { get; private set; }

        public string LastTransactionNumer { get; private set; }
    }
}