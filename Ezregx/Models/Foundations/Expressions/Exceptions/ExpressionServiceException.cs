using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezregx.Models.Foundations.Expressions.Exceptions
{
    public class ExpressionServiceException : Exception
    {
        public ExpressionServiceException(Exception exception) : base(message: "", exception)
        {
        }
    }
}
