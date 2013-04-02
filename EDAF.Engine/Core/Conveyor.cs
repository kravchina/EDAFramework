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

        protected void HandleVoid<TK>(T @event) where TK : IHandleVoid<T>
        {
            handleFactory.GetHandlerInstance<T>(typeof(TK)).Handle(@event);
        }

        protected void Handle<TK, TResult>(T @event) where TK : IHandleResult<T, TResult>
        {
            handleFactory.GetHandlerInstance<T,TResult>(typeof(TK)).Handle(@event);
        }

        public abstract void Send(T @event);

        public virtual K Receive<K>()
        {
            throw new Exception("This conveyor not return a value");
        }
    }
}
