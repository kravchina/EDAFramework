using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IBindToHandler<out T> where T : IEvent
    {
        IBindToHandler<T> ToHandler<TK>() where TK : IHandle<T>;
    }
}
