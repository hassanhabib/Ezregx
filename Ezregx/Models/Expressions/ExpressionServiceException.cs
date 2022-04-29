// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

namespace Ezregx.Models.Expressions
{
    public class ExpressionServiceException : Exception
    {
        public ExpressionServiceException(Exception innerException)
            : base(message: "Expression service error occurred, please contact support", innerException)
        { }
    }
}
