using System;

namespace StoneSoupAssessment.Exceptions
{
    public class NegativeNumbersException : Exception
    {
        public NegativeNumbersException(string message) : base(message) { }
    }
}
