using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class HandleResponse<T> : IHandleResponse<T> where T : IEvent
    {
        private readonly IHandle<T> handler;

        public HandleResponse(IHandle<T> handler)
        {
            this.handler = handler;
        }

        public TResponse GetResponse<TResponse>()
        {
            var responseHandler = handler as IResponse<TResponse>;

            if (responseHandler == null)
                throw new Exception("This handler conveyor can not return this type value");

            return responseHandler.Response();
        }
    }
}
