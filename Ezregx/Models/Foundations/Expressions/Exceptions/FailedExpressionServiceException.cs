using System;
using Xeptions;

namespace Ezregx.Models.Foundations.Expressions.Exceptions
{
    public class FailedExpressionServiceException : Xeption
    {
        public FailedExpressionServiceException(Exception innerException)
            : base(message: "Failed expression service occurred, please contact support", innerException)
        { }
    }
}
