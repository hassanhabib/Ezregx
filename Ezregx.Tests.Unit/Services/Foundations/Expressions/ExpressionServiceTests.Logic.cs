// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using System;
using System.Globalization;
using System.Reflection;
using Ezregx.Services.Foundations.Expressions;
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
                this.expressionService.GetStartExpression();

            // then
            actualExpressionStart.Should().BeEquivalentTo(
                expectedExpressionStart);
        }

        [Fact]
        public void DeleteMe()
        {
            MethodInfo methodInfo = typeof(ExpressionService)
                .GetMethod(nameof(this.expressionService.GetStartExpression));

            var memberInfo = methodInfo.DeclaringType.GetMembers();

            var x =
                ((MethodInfo[])((TypeInfo)(methodInfo).DeclaringType).DeclaredMethods)[1];

            //x.Invoking(fun=>fun.);

            var parameters = x.GetParameters();
            var value = parameters[0];

            Assert.True(true);
        }

        [Fact]
        public void DeleteMeTo()
        {
            //given
            MethodInfo? methodInfo = GetMethodInfo(nameof(this.expressionService.GetStartExpression));

            ExpressionService.ReturningStringFunction parameter
                                                    = () => throw new Exception();
            //when
            Action tryCatch = () => methodInfo.Invoke(this.expressionService,
                new object[] { parameter });

            //then
            tryCatch.Should()
                    .Throw<TargetInvocationException>()
                    .WithInnerException<Exception>(); 
        }


    }

}
