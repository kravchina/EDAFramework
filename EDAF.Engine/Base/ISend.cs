using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface ISend<T> where T : IEvent
    {
        void Send(T @event);
    }
}
