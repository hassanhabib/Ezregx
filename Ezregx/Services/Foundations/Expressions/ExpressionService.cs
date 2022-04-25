// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Brokers.Loggings;
using Ezregx.Models.Foundations.Expressions.Exceptions;
using System;
using Xeptions;

namespace Ezregx.Services.Foundations.Expressions
{
    public partial class ExpressionService : IExpressionService
    {
        private readonly ILoggingBroker loggingBroker;

        public ExpressionService(ILoggingBroker loggingBroker)
            => this.loggingBroker = loggingBroker;

        public string RetrieveStartExpression() =>
            TryCatch(() => GetStartExpression());

        private static string GetStartExpression() => "^";

        public delegate string ReturningStringFunction();

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

                throw CreateAndLogServiceException(failedExpressionServiceException);
            }
        }

        private ExpressionServiceException CreateAndLogServiceException(
           Xeption exception)
        {
            var commentServiceException = new ExpressionServiceException(exception);
            this.loggingBroker.LogError(commentServiceException);

            return commentServiceException;
        }
    }
}
