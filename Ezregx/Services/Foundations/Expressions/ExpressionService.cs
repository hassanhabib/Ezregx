// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Models.Foundations.Expressions.Exceptions;

namespace Ezregx.Services.Foundations.Expressions
{
    public partial class ExpressionService : IExpressionService
    {
        public string GetStartExpression() => TryCatch(() => "^");

        public delegate string ReturningStringFunction();

        public string TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (Exception ex)
            {
                throw new ExpressionServiceException(ex);
            }
        }

    }
}
