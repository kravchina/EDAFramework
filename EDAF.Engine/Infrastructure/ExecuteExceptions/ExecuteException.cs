using System;
using System.Net;
using EDAF.Engine.Base;

namespace EDAF.Engine.Infrastructure.ExecuteExceptions
{
    public abstract class ExecuteException : Exception, IExecuteException
    {
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}