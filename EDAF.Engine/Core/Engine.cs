using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class Engine : IEngine
    {
        private readonly IDictionary<Type, ICollection<Tuple<Type, bool>>> bindedHandler;

        private readonly IHandlerPool handlerPool;

        public Engine(IHandlerPool handlerPool)
        {
            this.handlerPool = handlerPool;

            bindedHandler = new Dictionary<Type, ICollection<Tuple<Type, bool>>>();
        }

        public IEventBinding<T> BindEvent<T>() where T : IEvent
        {
            var conveyor = new LinkedList<Tuple<Type, bool>>();

            bindedHandler.Add(typeof(T), conveyor);

            return new EventBinding<T>(conveyor);
        } 

        public IHandleResponse<T> Handle<T>(T @event) where T : IEvent
        {
            var handlerType = typeof (T);

            if (bindedHandler.ContainsKey(handlerType))
            {
                var conveyor = bindedHandler[handlerType];

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
