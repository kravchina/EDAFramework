using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IReadHandlerFactory
    {
        IReadHandler<IReadEvent<TResult>, TResult> GetHandlerInstance<TResult>(Type conveyorType);
        IReadHandler<TEvent, TResult> GetHandlerInstance<TEvent, TResult>(Type conveyorType) where TEvent : IReadEvent<TResult>;
    }
}
