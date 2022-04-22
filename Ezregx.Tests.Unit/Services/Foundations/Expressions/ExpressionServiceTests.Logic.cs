// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using System.Linq;
using System.Reflection;
using Ezregx.Services.Foundations.Expressions;
using FluentAssertions;
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

            var tryCatchMember = memberInfo.Where(m => m.Name == "TryCatch").First().DeclaringType;

            var tryCatchMethod = ((TypeInfo)tryCatchMember).DeclaredMethods.Where(m => m.Name == "TryCatch").First();

            ReturningStringFunction param = () => throw new System.Exception();

            var value = tryCatchMethod.Invoke(typeof(ExpressionService), new object[] { param });
            Assert.True(true);
        }
    }
}
