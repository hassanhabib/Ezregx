// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------

using Ezregx.Brokers.Loggings;
using Ezregx.Services.Foundations.Expressions;
using Moq;
using System;
using System.Linq.Expressions;

namespace Ezregx.Tests.Unit.Services.Foundations.Expressions
{
    public partial class ExpressionServiceTests
    {
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IExpressionService expressionService;

        public ExpressionServiceTests()
        {
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.expressionService = new ExpressionService(
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }
    }
}
