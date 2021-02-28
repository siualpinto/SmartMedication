using System;

namespace BussinessLogic.Entities.Entities
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
