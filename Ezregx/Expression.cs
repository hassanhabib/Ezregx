// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Services.Foundations.Expressions;

namespace Ezregx
{
    public static class Expression
    {
        private static IExpressionService ExpressionService =
            new ExpressionService();

        public static string OnStart(this string text) =>
            throw new NotImplementedException();
    }
}