using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base.Read;
using EDAF.Engine.Base.Write;

namespace EDAF.Engine.Base
{
    public interface IEventBinding<T> where T : IEvent
    {
        IEventBinding<T> Handle<TK>() where TK : IHandle<T>;
        IEventBinding<T> HandleAndRead<TK, TResponse>() where TK : IHandle<T>, IResponse<TResponse>;
    }

    
}
