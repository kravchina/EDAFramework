using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class WriteConveyor<T> : IWriteConveyor<T> where T : IWriteEvent
    {
        protected IHandleFactory handleFactory;

        private IWriteResponse _response;

        protected WriteConveyor(IHandleFactory handleFactory)
        {
            this.handleFactory = handleFactory;
        }

        public abstract void Run(T @event);

        public IWriteResponse GetResponse()
        {
            return _response;
        }

        protected void Handle<TK>(T @event) where TK : IWriteHandler<T>
        {
            var handler = handleFactory.GetHandlerInstance<T>(typeof(TK));

            handler.Handle(@event);

            var response = handler.GetResponse();

            if (response != null)
                _response = response;
        }
    }
}
