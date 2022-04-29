// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

namespace Ezregx.Models.Expressions
{
    public class FailedExpressionServiceException : Exception
    {
        public FailedExpressionServiceException(Exception innerException)
            : base(message: "Failed expression service error occurred, please contact support.", innerException)
        {

        }
    }
}
