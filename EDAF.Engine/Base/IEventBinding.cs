using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IEventBinding<out T> where T : IEvent
    {
        IEventBinding<T> ToHandler<TK>() where TK : IHandle<T>;
    }
}
