using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class Engine : IEngine
    {
        private readonly IEventBinding bindedHandlers;

        private readonly IHandlerPool handlerPool;

        private IPrincipal currentUser;

        public Engine(IHandlerPool handlerPool, IEventBinding bindedHandlers)
        {
            this.handlerPool = handlerPool;

            this.bindedHandlers = bindedHandlers;
        }

        public IHandleResponse<T> Handle<T>(T @event) where T : IEvent
        {
            var eventType = typeof(T);

            if (bindedHandlers.IsBinded(eventType))
            {
                var conveyor = bindedHandlers.GetHandledConveyor(eventType);

                IHandleResponse<T> handleResponse = new NullHandleResponse<T>();

                foreach (var bindedHandler in conveyor)
                {
                    var handler = handlerPool.GetHandler<T>(bindedHandler.HandlerType);

                    if (bindedHandler.IsRequiredUser)
                        ((IRequireUser)handler).SetUser(currentUser);

                    handler.Handle(@event);

                    if (bindedHandler.IsResponse)
                        handleResponse = new HandleResponse<T>(handler);
                }

                return handleResponse;

            }

            throw new KeyNotFoundException();
        }
    }
}
