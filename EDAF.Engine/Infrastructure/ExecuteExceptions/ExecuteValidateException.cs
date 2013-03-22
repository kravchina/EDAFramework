using System;
using System.Net;

namespace EDAF.Engine.Infrastructure.ExecuteExceptions
{
    public class ExecuteValidateException : ExecuteException 
    {
        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
