// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Models.Foundations.Expressions.Exceptions;
using Ezregx.Services.Foundations.Expressions;
using FluentAssertions;
using HarmonyLib;
using InternalMock.Extensions;
using System;
using System.Reflection;
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

        [Fact]
        public void ShouldThrowServiceException()
        {
            // given
            var exception = new Exception();

            this.expressionService.Mock(
                methodName: "GetStartExpression")
                .Throws(exception);

            // when
            Action retrieveStartExpression = () =>
            this.expressionService.RetrieveStartExpression();

            // then
            retrieveStartExpression.Should().Throw<ExpressionServiceException>();

            this.expressionService.ClearAllOtherCalls();
        }

        public static void ThrowException() => throw new Exception();
    }
}
