using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public sealed class ExecuteResponse : IExecuteResponse
    {
        private object _response;

        public ExecuteResponse(object response)
        {
            _response = response;
        }

        public TResponse GetResponse<TResponse>()
        {
            return (TResponse)_response;
        }
    }
}
