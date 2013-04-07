using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class Handler<T> : IHandle<T> where T : IEvent
    {
        private object _response;

        public abstract void Handle(T @event);

        protected void SetResponse<TResponse>(TResponse response)
        {
            _response = response;
        }

        public IExecuteResponse GetResponse()
        {
            if(_response != null)
                return new ExecuteResponse(_response);
            return null;
        }
    }
}
