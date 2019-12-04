using System;

namespace StoneSoupAssessment.LinkedList.Exceptions
{
    public class DeleteLinkedListNodeException : Exception
    {
        public DeleteLinkedListNodeException(string message) : base(message) { }
    }
}
