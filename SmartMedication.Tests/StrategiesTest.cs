using BussinessLogic.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SmartMedication.Tests.Mocks;
using System;
using WebApi.HttpStrategies.Post;

namespace SmartMedication.Tests
{
    public class Tests
    {
        protected MedicationManagerMock MedicationManagerMock { get; private set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPostMedicationWithSuccess()
        {
            IPostMedicationStrategy postMedicationStrategy = new PostMedicationStrategy(new MedicationManagerMock().Object);
            var guid = Guid.NewGuid();
            Medication medication = new Medication()
            {
                PKID = guid,
                CreationDate = DateTimeOffset.UtcNow,
                Name = $"test{guid}",
                Quantity = 3
            };
            var result = postMedicationStrategy.ExecutePostAsync(medication).Result;

            Assert.IsInstanceOf<StatusCodeResult>(result);
        }

        [Test]
        public void TestPostMedicationWithSuccess_Throws()
        {
            var mock = new MedicationManagerMock();
            mock.SetupToThrowException(new InvalidInputException("Error"));

            IPostMedicationStrategy postMedicationStrategy = new PostMedicationStrategy(mock.Object);
            var guid = Guid.NewGuid();
            Medication medication = new Medication()
            {
                PKID = guid,
                CreationDate = DateTimeOffset.UtcNow,
                Name = $"test{guid}",
                Quantity = 0
            };

            StatusCodeResult result = (StatusCodeResult)postMedicationStrategy.ExecutePostAsync(medication).Result;

            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}