// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using FluentAssertions;
using Xunit;

namespace Ezregx.Tests.Unit.Services.Foundations.Expressions
{
    public partial class ExpressionServiceTests
    {
        [Fact]
        public void ShouldGetExpressionStart()
        {
            // given
            string expectedExpressionStart = "^";

            // when
            string actualExpressionStart =
                this.expressionService.RetrieveStartExpression();

            // then
            actualExpressionStart.Should().BeEquivalentTo(
                expectedExpressionStart);
        }
    }
}
