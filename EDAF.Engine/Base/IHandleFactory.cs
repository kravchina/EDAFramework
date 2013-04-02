using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IHandleFactory
    {
        IHandleVoid<T> GetHandlerInstance<T>(Type handleType) where T : IEvent;
        IHandleResult<T,TResult> GetHandlerInstance<T, TResult>(Type handleType) where T : IEvent;
    }
}
