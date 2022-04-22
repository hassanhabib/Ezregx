// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using Ezregx.Models.Foundations.Expressions.Exceptions;
using Ezregx.Services.Foundations.Expressions;
using FluentAssertions;
using HarmonyLib;
using Xunit;
using static Ezregx.Services.Foundations.Expressions.ExpressionService;

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
            var harmony = new Harmony("whatever");

            var mOriginal = typeof(ExpressionService).GetMethod(
                "GetStartExpression",
                BindingFlags.NonPublic | BindingFlags.Static);

            var mPrefix = typeof(ExpressionServiceTests).GetMethod(
                "ThrowException",
                BindingFlags.Static | BindingFlags.Public);

            harmony.Patch(mOriginal, new HarmonyMethod(mPrefix));

            Assert.Throws<ExpressionServiceException>(() =>
                this.expressionService.RetrieveStartExpression());

            harmony.UnpatchAll();
        }

        public static void ThrowException() => throw new Exception();
    }
}
