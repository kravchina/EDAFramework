using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IHandleVoid<T> where T : IEvent
    {
        void Handle(T @event);
    }
}
