﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

namespace Ezregx.Services.Foundations.Expressions
{
    public partial class ExpressionService : IExpressionService
    {
        public string GetStartExpression() => TryCatch(() =>
            GetCaret());

        private static string GetCaret() => "^";
    }
}
