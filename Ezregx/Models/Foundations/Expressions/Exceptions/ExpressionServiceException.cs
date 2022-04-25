using System;

namespace Ezregx.Models.Foundations.Expressions.Exceptions
{
    public class ExpressionServiceException : Exception
    {
        public ExpressionServiceException(Exception exception) : base(message: "", exception)
        {
        }
    }
}
