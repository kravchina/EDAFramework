using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace EDAF.Engine.Infrastructure.ExecuteExceptions
{
    public class ExecuteAuthorizeException : ExecuteException
    {
        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.Unauthorized;
        }
    }
}
