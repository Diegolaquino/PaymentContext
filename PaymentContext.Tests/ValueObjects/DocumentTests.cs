using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, green, Refactor
        // Red -> Primeiro fazer todos os testes falharem
        // Green -> Fazer todos os testes passarem
        // Refactor -> Refatorar os testes

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);

            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsValid()
        {
            var doc = new Document("12345678974589", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123456789745", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("12960405769")]
        [DataRow("12960405768")]
        [DataRow("12960405767")]
        [DataRow("12960405766")]
        [DataRow("12960405765")]
        public void ShouldReturnSucessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
