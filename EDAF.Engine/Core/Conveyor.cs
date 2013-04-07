using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class Conveyor<T> : IConveyor<T> where T : IEvent
    {
        protected IHandleFactory handleFactory;

        protected Conveyor(IHandleFactory handleFactory)
        {
            this.handleFactory = handleFactory;
        }

        public abstract void Run(T @event);

        protected void Handle<TK>(T @event) where TK : IHandle<T>
        {
            handleFactory.GetHandlerInstance<T>(typeof(TK)).Handle(@event);
        }
    }

    public abstract class Conveyor<T, TResponse> : IConveyor<T, TResponse> where T : IEvent
    {
        protected IHandleFactory handleFactory;

        private TResponse _response;

        protected Conveyor(IHandleFactory handleFactory)
        {
            this.handleFactory = handleFactory;
        }

        public abstract void Run(T @event);

        protected void Handle<TK>(T @event) where TK : IHandle<T>
        {
            handleFactory.GetHandlerInstance<T>(typeof(TK)).Handle(@event);
        }

        protected void HandleAndGetResponse<TK>(T @event) where TK : IHandle<T, TResponse>
        {
            var handler = handleFactory.GetHandlerInstance<T, TResponse>(typeof(TK));

            handler.Handle(@event);

            _response = handler.GetResponse();
        } 

        public TResponse GetResponse()
        {
            return _response;
        }
    }
}
