// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Services.Foundations.Expressions;
using FluentAssertions;
using Xeptions;

namespace Ezregx.Tests.Unit.Services.Foundations.Expressions
{
    public partial class ExpressionServiceTests
    {
        private readonly IExpressionService expressionService;

        public ExpressionServiceTests() =>
            this.expressionService = new ExpressionService();

        private void AssertExceptionsAreSame(
            Xeption actualException,
            Xeption expectedException)
        {
            actualException.Message.Should().BeEquivalentTo(expectedException.Message);

            actualException.InnerException.GetType().Should().Be(
                expectedException.InnerException.GetType());

            actualException.InnerException.Message.Should().BeEquivalentTo(
                expectedException.InnerException.Message);
        }
    }
}
