using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IReadEngine
    {
        TResult Read<TResult>(IReadEvent<TResult> @event);
        // Test methods
        TResult Read<TRequest, TResult>(TRequest @event) where TRequest : IReadEvent<TResult>;
        void SetHandlerFactory(IReadHandlerFactory factory);
    }
}
