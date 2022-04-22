// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using System;
using Ezregx.Models.Foundations.Expressions.Exceptions;

namespace Ezregx.Services.Foundations.Expressions
{
    public partial class ExpressionService : IExpressionService
    {

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
                throw new ExpressionServiceException(exception);
            }
        }
    }
}
