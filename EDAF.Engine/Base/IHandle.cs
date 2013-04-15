using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IHandle<in T> where T : IEvent
    {
        void Handle(T @event);
    }
}
