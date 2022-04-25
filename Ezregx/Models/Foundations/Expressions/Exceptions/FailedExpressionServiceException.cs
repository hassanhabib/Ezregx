using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Ezregx.Models.Foundations.Expressions.Exceptions
{
    public class FailedExpressionServiceException : Xeption
    {
        public FailedExpressionServiceException(Exception innerException)
            : base(message: "Failed expression service occurred, please contact support", innerException)
        { }
    }
}
