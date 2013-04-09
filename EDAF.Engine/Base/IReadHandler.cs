using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IReadHandler<T, TResult> where T : IReadEvent<TResult>
    {
        TResult Handle(T @event);
        T PreRequest(T @event);
        TResult Request(T @event);
        TResult PostRequest(T @event, TResult result);
    }
}
