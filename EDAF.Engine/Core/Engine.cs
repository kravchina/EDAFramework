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
                    
                    handler.Handle(@event);

                    if (bindedHandler.IsResponse)
                        handleResponse = new HandleResponse<T>(handler);
                }

                return handleResponse;
            }

            throw new KeyNotFoundException();
        }

        public IHandleResponse<T> Handle<T, T1>(T @event, T1 arg1) where T : IEvent
        {
            var eventType = typeof(T);

            if (bindedHandlers.IsBinded(eventType))
            {
                var conveyor = bindedHandlers.GetHandledConveyor(eventType);

                IHandleResponse<T> handleResponse = new NullHandleResponse<T>();

                foreach (var bindedHandler in conveyor)
                {
                    var handler = handlerPool.GetHandler<T>(bindedHandler.HandlerType);

                    if (bindedHandler.IsNeedType(typeof (T1)))
                    {
                        ((INeed<T1>)handler).Inject(arg1);
                    }

                    handler.Handle(@event);

                    if (bindedHandler.IsResponse)
                        handleResponse = new HandleResponse<T>(handler);
                }

                return handleResponse;
            }

            throw new KeyNotFoundException();
        }

        public IHandleResponse<T> Handle<T, T1, T2>(T @event, T1 arg1, T2 arg2) where T : IEvent
        {
            var eventType = typeof(T);

            if (bindedHandlers.IsBinded(eventType))
            {
                var conveyor = bindedHandlers.GetHandledConveyor(eventType);

                IHandleResponse<T> handleResponse = new NullHandleResponse<T>();

                foreach (var bindedHandler in conveyor)
                {
                    var handler = handlerPool.GetHandler<T>(bindedHandler.HandlerType);

                    if (bindedHandler.IsNeedType(typeof(T1)))
                    {
                        ((INeed<T1>)handler).Inject(arg1);
                    }

                    if (bindedHandler.IsNeedType(typeof(T2)))
                    {
                        ((INeed<T2>)handler).Inject(arg2);
                    }

                    handler.Handle(@event);

                    if (bindedHandler.IsResponse)
                        handleResponse = new HandleResponse<T>(handler);
                }

                return handleResponse;
            }

            throw new KeyNotFoundException();
        }

        public IHandleResponse<T> Handle<T, T1, T2, T3>(T @event, T1 arg1, T2 arg2, T3 arg3) where T : IEvent
        {
            throw new NotImplementedException();
        }

        public void SetUser(IPrincipal user)
        {
            currentUser = user;
        }
    }
}
