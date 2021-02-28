using BussinessLogic.Entities.Entities;
using BussinessLogic.Loaders;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMedication.Tests.Mocks
{
    public class MedicationLoaderMock : Mock<IMedicationLoader>
    {
        public MedicationLoaderMock()
        {
            Setup();
        }

        protected virtual void Setup()
        {
            this.Setup(m => m.GetAllAsync())
               .Returns(async () =>
               {
                   List<Medication> list = new List<Medication>();
                   return await Task.FromResult(list);
               });
            this.Setup(m => m.GetByIdAsync(It.IsAny<Guid>())).Returns(async () =>
            {
                var guid = Guid.NewGuid();
                Medication medication = new Medication()
                {
                    PKID = guid,
                    CreationDate = DateTimeOffset.UtcNow,
                    Name = $"test{guid}",
                    Quantity = 3
                };
                return await Task.FromResult(medication);
            });
        }
    }
}
