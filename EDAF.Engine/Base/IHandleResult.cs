using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IHandleResult<T, TResult> where T : IEvent
    {
        TResult Handle(T @event);
    }
}
