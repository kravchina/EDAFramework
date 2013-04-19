using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IEngine : IRequireUser
    {
        IHandleResponse<T> Handle<T>(T @event) where T : IEvent;
    }
}
