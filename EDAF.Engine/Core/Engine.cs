using System;
using System.Collections.Generic;
using EDAF.Engine.Base;
using EDAF.Engine.Core.Infrastructure;

namespace EDAF.Engine.Core
{
    public class Engine
    {
        protected readonly Dictionary<Type, ICollection<Tuple<Type, bool>>> bindedHandlers;

        protected IHandlerPool handlerPool;

        public Engine()
        {
            bindedHandlers = new Dictionary<Type, ICollection<Tuple<Type, bool>>>();
        }

        public IEventBinding<T> BindEvent<T>() where T : IEvent
        {
            var conveyor = new LinkedList<Tuple<Type, bool>>();

            bindedHandlers.Add(typeof(T), conveyor);

            return new EventBinding<T>(conveyor);
        }

        public void Handle<T>(T @event) where T : IEvent
        {
            var eventType = typeof (T);

            if (bindedHandlers.ContainsKey(eventType))
            {
                var conveyor = bindedHandlers[eventType];
                
                foreach (var handleType in conveyor)
                {
                    var handler = handlerPool.GetHandler<T>(handleType.Item1);

                    handler.Handle(@event);
                }
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public TResponse Handle<T, TResponse>(T @event) where T : IEvent
        {
            var eventType = typeof(T);

            if (bindedHandlers.ContainsKey(eventType))
            {
                var conveyor = bindedHandlers[eventType];

                TResponse response;

                foreach (var handleType in conveyor)
                {
                    var handler = handlerPool.GetHandler<T>(handleType.Item1);

                    handler.Handle(@event);

                    if(handleType.Item2)
                    {
                        response = ((IResponse<TResponse>)handler).Response();
                    }
                }

                return response;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
