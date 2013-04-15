using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;
using EDAF.Engine.Base.Write;

namespace EDAF.Engine.Core
{
    public sealed class WriteResponse : IWriteResponse
    {
        private object _response;

        public WriteResponse(object response)
        {
            _response = response;
        }

        public TResponse GetResponse<TResponse>()
        {
            return (TResponse)_response;
        }
    }
}
