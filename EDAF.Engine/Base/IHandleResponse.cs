using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IHandleResponse<T> where T : IEvent
    {
        TResponse GetResponse<TResponse>();
    }
}
