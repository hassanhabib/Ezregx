// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using System;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
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
            TryCatchInject.Setup(this.expressionService);

            //when
            Action action = () => this.expressionService.GetStartExpression();

            //then
            action.Should().Throw<Exception>();
        }


    }

    public class TryCatchInject
    {
        private static object target;
        private const string method = "TryCatch";
        public TryCatchInject()
        {
        }
        public static void Setup(object target)
        {
            TryCatchInject.target = target;

            MethodInfo methodToReplace = target.GetType().GetMethod(method);
            MethodInfo methodToInject = typeof(TryCatchInject).GetMethod(method);
            RuntimeHelpers.PrepareMethod(methodToReplace.MethodHandle);
            RuntimeHelpers.PrepareMethod(methodToInject.MethodHandle);

            unsafe
            {
                if (IntPtr.Size == 4)
                {
                    int* inj = (int*)methodToInject.MethodHandle.Value.ToPointer() + 2;
                    int* tar = (int*)methodToReplace.MethodHandle.Value.ToPointer() + 2;
                    *tar = *inj;
                }
                else
                {

                    long* inj = (long*)methodToInject.MethodHandle.Value.ToPointer() + 1;
                    long* tar = (long*)methodToReplace.MethodHandle.Value.ToPointer() + 1;
                    *tar = *inj;
                }
            }
        }

        public string TryCatch()
        {
            throw new Exception();
        }
    }

}
