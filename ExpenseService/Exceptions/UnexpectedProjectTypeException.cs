using System;
namespace Expense.Service.Exceptions
{
    public class UnexpectedProjectTypeException : Exception
    {
        public UnexpectedProjectTypeException(string message) : base(message)
        {
        }
    }
}
