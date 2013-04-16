using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IEventBinding
    {
        IBindToHandler<T> BindEvent<T>() where T : IEvent;
        ICollection<Tuple<Type, bool>> GetHandledConveyor(Type eventType);
        bool IsBinded(Type eventType);
    }
}
