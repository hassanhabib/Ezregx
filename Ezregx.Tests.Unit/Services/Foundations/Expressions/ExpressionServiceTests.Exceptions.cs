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

            // when
            Action getStartExpressionAction = () =>
                this.expressionService.GetStartExpression();

            // then
            ExpressionServiceException expressionServiceException =
                Assert.Throws<ExpressionServiceException>(getStartExpressionAction);

            Assert.True(expressionServiceException.InnerException 
                is FailedExpressionServiceException);

            this.expressionService.ClearAllOtherCalls();
        }
    }
}
