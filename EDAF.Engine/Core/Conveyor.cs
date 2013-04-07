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

        private IExecuteResponse _response;

        protected Conveyor(IHandleFactory handleFactory)
        {
            this.handleFactory = handleFactory;
        }

        public abstract void Run(T @event);

        public IExecuteResponse GetResponse()
        {
            return _response;
        }

        protected void Handle<TK>(T @event) where TK : IHandle<T>
        {
            var handler = handleFactory.GetHandlerInstance<T>(typeof(TK));

            handler.Handle(@event);

            var response = handler.GetResponse();

            if (response != null)
                _response = response;
        }
    }
}
