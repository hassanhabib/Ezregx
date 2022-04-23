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
using Ezregx.Models.Foundations.Expressions.Exceptions;
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
            TryCatchInject.Service = this.expressionService as ExpressionService;
            new TryCatchInject().Set();

            //when
            Action action = () => this.expressionService.GetStartExpression();

            //then
            action.Should().Throw<ExpressionServiceException>();
        }


    }


    public unsafe class TryCatchInject
    {
        public static ExpressionService Service;
        private const string method = "TryCatch";
        private IntPtr originalMethodPtr;
        private IntPtr hookMethodPtr;
        public TryCatchInject()
        {

        }
        public void Set()
        {
            MethodInfo originalMethod = typeof(ExpressionService).GetMethod(method);
            MethodInfo hookMethod = typeof(TryCatchInject).GetMethod(method);
            RuntimeHelpers.PrepareMethod(originalMethod.MethodHandle);
            RuntimeHelpers.PrepareMethod(hookMethod.MethodHandle);
            hookMethodPtr = hookMethod.MethodHandle.Value;
            originalMethodPtr = originalMethod.MethodHandle.Value;

            if (IntPtr.Size == 4)
            {
                int* hook = (int*)hookMethodPtr.ToPointer() + 2;
                int* tar = (int*)originalMethodPtr.ToPointer() + 2;
                *tar = *hook;
            }
            else
            {
                long* hook = (long*)hookMethodPtr.ToPointer() + 1;
                long* tar = (long*)originalMethodPtr.ToPointer() + 1;
                *tar = *hook;
            }
        }

        public void Unset()
        {
            MethodInfo originalMethod = typeof(ExpressionService).GetMethod(method);
            MethodInfo hookMethod = typeof(TryCatchInject).GetMethod(method);
            RuntimeHelpers.PrepareMethod(originalMethod.MethodHandle);
            RuntimeHelpers.PrepareMethod(hookMethod.MethodHandle);
            hookMethodPtr = hookMethod.MethodHandle.Value;
            originalMethodPtr = originalMethod.MethodHandle.Value;

            if (IntPtr.Size == 4)
            {
                int* hook = (int*)hookMethodPtr.ToPointer() + 2;
                int* tar = (int*)originalMethodPtr.ToPointer() + 2;
                *hook = *tar;
            }
            else
            {

                long* hook = (long*)hookMethodPtr.ToPointer() + 1;
                long* tar = (long*)originalMethodPtr.ToPointer() + 1;
                *hook = *tar;
            }
        }

        public string TryCatch()
        {
            ExpressionService.ReturningStringFunction parameter 
                                                    = () => throw new Exception();
            Unset();
            return Service.TryCatch(parameter);
        }
    }

}
