using System;
using System.Collections.Generic;
using EDAF.Engine.Base;
using EDAF.Engine.Base.Infrastructure;
using EDAF.Engine.Base.Read;
using EDAF.Engine.Base.Write;
using EDAF.Engine.Core.Infrastructure;

namespace EDAF.Engine.Core
{
    public class Engine : IEngine
    {
        protected readonly Dictionary<Type, ICollection<Type>> bindedWriteHandlers;

        protected readonly Dictionary<Type, Type> bindedReadHandlers;

        protected IWriteHandlerPool writeHandlerPool;

        protected IReadHandlerPool readHandlerPool;

        public Engine()
        {
            bindedWriteHandlers = new Dictionary<Type, ICollection<Type>>();
        }

        public IWriteEventBinding<T> BindEvent<T>() where T : IWriteEvent
        {
            var conveyor = new LinkedList<Type>();

            bindedWriteHandlers.Add(typeof(T), conveyor);

            return new WriteEventBinding<T>(conveyor);
        }

        public IReadEventBinding<T, TK> BindEvent<T, TK>() where T : IReadEvent<TK>
        {
            throw new NotImplementedException();
        }

        public IWriteResponse Write<T>(T @event) where T : IWriteEvent
        {
            var eventType = typeof (T);

            if (bindedWriteHandlers.ContainsKey(eventType))
            {
                var conveyor = bindedWriteHandlers[eventType];

                IWriteResponse response = null;

                foreach (var handleType in conveyor)
                {
                    var handler = writeHandlerPool.GetHandler<T>(handleType);

                    handler.Handle(@event);

                    var handlerResponse = handler.GetResponse();

                    if (handlerResponse != null)
                        response = handlerResponse;
                }

                return response;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public TResult Read<TRequest, TResult>(TRequest @event) where TRequest : IReadEvent<TResult>
        {
            var requestType = typeof(TRequest);

            if (bindedWriteHandlers.ContainsKey(requestType))
            {
                var handlerType = bindedReadHandlers[requestType];

                var handler = readHandlerPool.GetHandler<TRequest, TResult>(handlerType);

                return handler.Handle(@event);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
