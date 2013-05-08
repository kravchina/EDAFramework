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
        private readonly IEventBinding eventBinding;

        private readonly IHandlerPool handlerPool;

        private IPrincipal currentUser;

        public Engine(IHandlerPool handlerPool, IEventBinding eventBinding)
        {
            this.handlerPool = handlerPool;

            this.eventBinding = eventBinding;
        }

        public IHandleResponse<T> Handle<T>(T @event) where T : IEvent
        {
            var conveyor = GetConveyor(typeof(T));

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

        

        public IHandleResponse<T> Handle<T, T1>(T @event, T1 arg1) where T : IEvent
        {
            var conveyor = GetConveyor(typeof(T));

            IHandleResponse<T> handleResponse = new NullHandleResponse<T>();

            foreach (var bindedHandler in conveyor)
            {
                var handler = handlerPool.GetHandler<T>(bindedHandler.HandlerType);

                Inject(arg1, handler, bindedHandler);

                handler.Handle(@event);

                if (bindedHandler.IsResponse)
                    handleResponse = new HandleResponse<T>(handler);
            }

            return handleResponse;
        }

        private void Inject<T, T1>(T1 arg1, IHandle<T> handler, BindedHandler bindedHandler) where T : IEvent
        {
            if (bindedHandler.IsNeedType(typeof (T1)))
            {
                ((INeed<T1>) handler).Inject(arg1);
            }
        }

        private ICollection<BindedHandler> GetConveyor(Type eventType)
        {
            if (eventBinding.IsBinded(eventType))
            {
                return eventBinding.GetHandledConveyor(eventType);
            }

            throw new KeyNotFoundException();
        } 

        public IHandleResponse<T> Handle<T, T1, T2>(T @event, T1 arg1, T2 arg2) where T : IEvent
        {
            var conveyor = GetConveyor(typeof(T));

            IHandleResponse<T> handleResponse = new NullHandleResponse<T>();

            foreach (var bindedHandler in conveyor)
            {
                var handler = handlerPool.GetHandler<T>(bindedHandler.HandlerType);

                Inject(arg1, handler, bindedHandler);
                Inject(arg2, handler, bindedHandler);

                handler.Handle(@event);

                if (bindedHandler.IsResponse)
                    handleResponse = new HandleResponse<T>(handler);
            }

            return handleResponse;
        }

        public IHandleResponse<T> Handle<T, T1, T2, T3>(T @event, T1 arg1, T2 arg2, T3 arg3) where T : IEvent
        {
            var conveyor = GetConveyor(typeof(T));

            IHandleResponse<T> handleResponse = new NullHandleResponse<T>();

            foreach (var bindedHandler in conveyor)
            {
                var handler = handlerPool.GetHandler<T>(bindedHandler.HandlerType);

                Inject(arg1, handler, bindedHandler);
                Inject(arg2, handler, bindedHandler);
                Inject(arg3, handler, bindedHandler);

                handler.Handle(@event);

                if (bindedHandler.IsResponse)
                    handleResponse = new HandleResponse<T>(handler);
            }

            return handleResponse;
        }
    }
}
