using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base.Read
{
    public interface IReadHandler<TRequest, TResult> where TRequest : IReadEvent<TResult>
    {
        TResult Handle(TRequest @event);
        TRequest PreRequest(TRequest @event);
        TResult Request(TRequest @event);
        TResult PostRequest(TRequest @event, TResult result);
    }
}
