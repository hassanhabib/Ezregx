// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Models.Expressions;

namespace Ezregx.Services.Foundations.Expressions
{
    public partial class ExpressionService
    {
        private delegate string ReturningStringFunction();

        private string TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (Exception exception)
            {
                var failedExpressionServiceException =
                    new FailedExpressionServiceException(exception);

                throw new ExpressionServiceException(failedExpressionServiceException);
            }
        }
    }
}
