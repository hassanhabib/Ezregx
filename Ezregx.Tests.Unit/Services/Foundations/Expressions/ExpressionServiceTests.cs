// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Services.Foundations.Expressions;
using Moq;
using System.Reflection;
using static Ezregx.Services.Foundations.Expressions.ExpressionService;

namespace Ezregx.Tests.Unit.Services.Foundations.Expressions
{
    public partial class ExpressionServiceTests
    {
        private readonly IExpressionService expressionService;
        private readonly Mock<ReturningStringFunction> returningStringFunctionMock;

        public ExpressionServiceTests()
        {
            this.expressionService = new ExpressionService();
            this.returningStringFunctionMock = new Mock<ReturningStringFunction>();
        }


        private MethodInfo? GetMethodInfo(string methodName)
        {
            MethodInfo? methodInfo = typeof(ExpressionService)
                .GetMethod(methodName);

            return ((methodInfo?.DeclaringType as TypeInfo)?.DeclaredMethods as MethodInfo[])?[1];
        }
    }
}
