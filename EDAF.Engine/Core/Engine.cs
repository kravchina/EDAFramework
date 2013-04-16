using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class Engine : IEngine
    {
        private readonly IEventBinding bindedHandler;

        private readonly IHandlerPool handlerPool;

        public Engine(IHandlerPool handlerPool, IEventBinding bindedHandlers)
        {
            this.handlerPool = handlerPool;

            this.bindedHandler = bindedHandlers;
        }

        public IHandleResponse<T> Handle<T>(T @event) where T : IEvent
        {
            var eventType = typeof (T);

            if (bindedHandler.IsBinded(eventType))
            {
                var conveyor = bindedHandler.GetHandledConveyor(eventType);

                IHandleResponse<T> handleResponse = new NullHandleResponse<T>();

                foreach (var tuple in conveyor)
                {
                    var handler = handlerPool.GetHandler<T>(tuple.Item1);

                    handler.Handle(@event);

                    if(tuple.Item2)
                        handleResponse = new HandleResponse<T>(handler);
                }

                return handleResponse;

            }

            throw new KeyNotFoundException();
        }
    }
}
