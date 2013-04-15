using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base.Read
{
    public interface IReadEngine
    {
        TResult Read<TRequest, TResult>(TRequest @event) where TRequest : IReadEvent<TResult>;
    }
}
