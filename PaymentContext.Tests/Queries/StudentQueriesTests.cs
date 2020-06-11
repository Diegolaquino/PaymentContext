using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private readonly IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for (int i = 0; i <= 10; i++)
            {
                _students.Add(
                    new Student(
                        new Name("Aluno", i.ToString()), 
                        new Document("12960405775", EDocumentType.CPF), 
                        new Email("diegol.aquino@gmail.com")
                    )
                 );
            }
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");

            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }
    }
}
