using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, green, Refactor
        // Red -> Primeiro fazer todos os testes falharem
        // Green -> Fazer todos os testes passarem
        // Refactor -> Refatorar os testes

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.BarCode = "";

            command.FirstName = "Diego";

            command.LastName = "Aquino";

            command.Document = "99999999999";

            command.Email = "diegol.aquino@gmail.ch";

            command.BoletoNumber = "123456789";

            command.PaymentNumber = "1234567890";

            command.PaidDate = DateTime.Now;

            command.ExpireDate = DateTime.Now.AddMonths(1);

            command.Total = 60;

            command.TotalPaid = 60;

            command.Payer = "Nezoo Design";

            command.PayerDocument = "123456789";

            command.PayerDocumentType = EDocumentType.CPF;

            command.PayerEmail = "diegol.aquino@gmail.com";

            command.Street = "Rua são fernando";

            command.Number = "77";

            command.Neighborhood = "Cascadura";

            command.City = "Rio de Janeiro";

            command.State = "Rio de Janeiro";

            command.Country = "Brasil";

            command.ZipCode = "20740320";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);



        }
    }
}
