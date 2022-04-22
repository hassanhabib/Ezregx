// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Services.Foundations.Expressions;

namespace Ezregx.Tests.Unit.Services.Foundations.Expressions
{
    public partial class ExpressionServiceTests
    {
        private readonly IExpressionService expressionService;

        public ExpressionServiceTests() =>
            this.expressionService = new ExpressionService();
    }
}
