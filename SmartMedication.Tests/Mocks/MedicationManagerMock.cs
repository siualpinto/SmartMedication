using BussinessLogic.Entities.Entities;
using BussinessLogic.Managers;
using Moq;
using System;
using System.Threading.Tasks;

namespace SmartMedication.Tests.Mocks
{
    public class MedicationManagerMock : Mock<IMedicationManager>
    {
        public MedicationManagerMock()
        {
            Setup();
        }

        private void Setup()
        {
            this.Setup(m => m.AddAsync(It.IsAny<Medication>())).Returns((Task<Medication> e) => e);
            this.Setup(m => m.DeleteAsync(It.IsAny<Guid>()));
        }

        public  void SetupToThrowException(Exception exception)
        {
            this.Setup(m => m.AddAsync(It.IsAny<Medication>())).Throws(exception);
            this.Setup(m => m.DeleteAsync(It.IsAny<Guid>())).Throws(exception);
        }
    }
}
