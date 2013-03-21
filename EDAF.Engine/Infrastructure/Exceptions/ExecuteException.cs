using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EDAF.Engine.Base;

namespace EDAF.Engine.Infrastructure.Exceptions
{
    public abstract class ExecuteException : Exception, IExecuteException
    {
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
