using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IHandle<T> where T : IEvent
    {
        void Handle(T @event);
        IExecuteResponse GetResponse();
    }
}
