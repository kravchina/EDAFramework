using System;
using System.Collections.Generic;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class Engine : IEngine
    {
        protected readonly Dictionary<Type, Type> conveyors;

        protected IConveyorFactory conveyorFactory;

        protected IReadHandlerFactory readHandlerFactory;

        public Engine()
        {
            conveyors = new Dictionary<Type, Type>();
        }

        public void Bind(Type eventType, Type conveyorType)
        {
            conveyors.Add(eventType, conveyorType);
        }

        public IExecuteResponse Write<T>(T @event) where T : IWriteEvent
        {
            if (conveyors.ContainsKey(typeof(T)))
            {
                var conveyorType = conveyors[typeof(T)];

                var conveyor = conveyorFactory.GetConveyorInstance<T>(conveyorType);

                conveyor.Run(@event);

                return conveyor.GetResponse();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void SetConveyorFactory(IConveyorFactory factory)
        {
            conveyorFactory = factory;
        }

        public IBindEventTo<T> BindEvent<T>() where T : IWriteEvent
        {
            return new BindEventTo<T>(this);
        }

        public TResult Read<TResult>(IReadEvent<TResult> @event)
        {
            var eventType = @event.GetType();

            if (conveyors.ContainsKey(eventType))
            {
                var handlerType = conveyors[eventType];

                var handler = readHandlerFactory.GetHandlerInstance<TResult>(handlerType);

                return handler.Handle(@event);

            }
            else
            {
                throw new KeyNotFoundException();
            }
            /*throw new NotImplementedException();*/
        }

        public TResult Read<TRequest, TResult>(TRequest @event) where TRequest : IReadEvent<TResult>
        {

            if (conveyors.ContainsKey(typeof(TRequest)))
            {
                var handlerType = conveyors[typeof(TRequest)];

                var handler = readHandlerFactory.GetHandlerInstance<TRequest, TResult>(handlerType);

                return handler.Handle(@event);

            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void SetHandlerFactory(IReadHandlerFactory factory)
        {
            readHandlerFactory = factory;
        }
    }
}
