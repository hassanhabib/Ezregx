using Ezregx.Models.Foundations.Expressions.Exceptions;
using FluentAssertions;
using InternalMock.Extensions;
using Moq;
using System;
using Xunit;

namespace Ezregx.Tests.Unit.Services.Foundations.Expressions
{
    public partial class ExpressionServiceTests
    {

        [Fact]
        public void ShouldThrowServiceException()
        {
            // given
            var serviceException = new Exception();

            var failedExpressionServiceException =
               new FailedExpressionServiceException(serviceException);

            var expectedExpressionServiceException =
                new ExpressionServiceException(failedExpressionServiceException);

            this.expressionService.Mock(
                methodName: "GetStartExpression")
                .Throws(serviceException);

            // when
            Action retrieveStartExpression = () =>
                this.expressionService.RetrieveStartExpression();

            // then
            retrieveStartExpression.Should()
                                   .Throw<ExpressionServiceException>()
                                   .WithInnerException<FailedExpressionServiceException>();

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExpressionServiceException))),
                        Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();

            this.expressionService.ClearAllOtherCalls();
        }
    }
}
