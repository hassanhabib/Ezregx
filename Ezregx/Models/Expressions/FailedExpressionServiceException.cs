// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Xeptions;

namespace Ezregx.Models.Expressions
{
    public class FailedExpressionServiceException : Xeption
    {
        public FailedExpressionServiceException(Exception innerException)
            : base(message: "Failed expression service error occurred, please contact support.", innerException)
        { }
    }
}
