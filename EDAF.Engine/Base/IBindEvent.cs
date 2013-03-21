using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IBindEvent
    {
        void Bind(Type eventType, Type conveyorType);

        IBindEventTo<T> BindEvent<T>() where T : IEvent;
    }
}
