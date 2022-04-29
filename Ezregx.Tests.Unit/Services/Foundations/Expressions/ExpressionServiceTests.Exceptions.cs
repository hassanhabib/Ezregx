// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using System;
using Ezregx.Models.Expressions;
using InternalMock.Extensions;
using Xunit;

namespace Ezregx.Tests.Unit.Services.Foundations.Expressions
{
    public partial class ExpressionServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnGetStartIfExceptionOccurs()
        {
            // given
            var exception = new Exception();

            this.expressionService.Mock(
                methodName: "GetCaret")
                    .Throws(exception);

            var failedExpressionServiceException =
                new FailedExpressionServiceException(exception);

            var expectedExpressionServiceException =
                new ExpressionServiceException(failedExpressionServiceException);

            // when
            Action getStartExpressionAction = () =>
                this.expressionService.GetStartExpression();

            // then
            ExpressionServiceException actualExpressionServiceException =
                Assert.Throws<ExpressionServiceException>(getStartExpressionAction);

            AssertExceptionsAreSame(
                actualExpressionServiceException,
                expectedExpressionServiceException);

            this.expressionService.ClearAllOtherCalls();
        }
    }
}
