﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string FakeTryCatch(ReturningStringFunction returningStringFunction)
        {
            throw new Exception();
        }
    }
}
