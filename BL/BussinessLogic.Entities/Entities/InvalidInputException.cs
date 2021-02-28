using System;

namespace BussinessLogic.Entities.Entities
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}
