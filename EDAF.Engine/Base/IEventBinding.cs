using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Core;

namespace EDAF.Engine.Base
{
    public interface IEventBinding
    {
        IBindToHandler<T> BindEvent<T>() where T : IEvent;
        ICollection<HandlerUnit> GetHandledConveyor(Type eventType);
        bool IsBinded(Type eventType);
    }
}
