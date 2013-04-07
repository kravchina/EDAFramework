using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class Handler<T> : IHandle<T> where T : IEvent
    {
        public abstract void Handle(T @event);
    }

    public abstract class Handler<T, TResponse> : IHandle<T, TResponse> where T : IEvent
    {
        protected TResponse Response;

        public TResponse GetResponse()
        {
            return Response;
        }

        public abstract void Handle(T @event);
    }
}
