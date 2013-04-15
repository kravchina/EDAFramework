using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class NullHandleResponse<T> : IHandleResponse<T> where T : IEvent
    {
        public TResponse GetResponse<TResponse>()
        {
            throw new Exception("This handlers can not return value!");
        }
    }
}
