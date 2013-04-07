using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IHandleFactory
    {
        IHandle<T> GetHandlerInstance<T>(Type handleType) where T : IEvent;
        IHandle<T,TResponse> GetHandlerInstance<T, TResponse>(Type handleType) where T : IEvent;
    }
}
