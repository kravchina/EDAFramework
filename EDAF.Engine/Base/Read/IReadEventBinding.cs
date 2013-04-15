using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base.Read
{
    public interface IReadEventBinding<TRequest, TResponse> where TRequest : IReadEvent<TResponse>
    {
        Void ToHandler<TK>() where TK : IReadHandler<TRequest, TResponse>;
    } 
}
