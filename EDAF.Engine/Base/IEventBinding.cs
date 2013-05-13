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
        ICollection<Binding> GetHandledConveyor(Type eventType);
        bool IsBinded(Type eventType);
    }
}
