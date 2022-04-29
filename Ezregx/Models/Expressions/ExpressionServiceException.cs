// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Xeptions;

namespace Ezregx.Models.Expressions
{
    public class ExpressionServiceException : Xeption
    {
        public ExpressionServiceException(Xeption innerException)
            : base(message: "Expression service error occurred, please contact support", innerException)
        { }
    }
}
