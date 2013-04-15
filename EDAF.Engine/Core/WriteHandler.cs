using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class WriteHandler<T> : IWriteHandler<T> where T : IWriteEvent
    {
        private object _response;

        public abstract void Handle(T @event);

        protected void SetResponse<TResponse>(TResponse response)
        {
            _response = response;
        }

        public IWriteResponse GetResponse()
        {
            if(_response != null)
                return new WriteResponse(_response);
            return null;
        }
    }
}
