using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base.Read
{
    public interface IReadHandlerPool
    {
        IReadHandler<TRequest, TResult> GetHandler<TRequest, TResult>(Type type) where TRequest : IReadEvent<TResult>;
    }
}
