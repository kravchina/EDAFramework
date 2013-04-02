using System;
using System.Collections.Generic;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class StandardEngine : IStandardEngine
    {
        protected readonly Dictionary<Type, Type> conveyors;

        protected IConveyorFactory conveyorFactory;

        protected IReceive currentConveyor;

        public StandardEngine()
        {
            conveyors = new Dictionary<Type, Type>();
        }

        public void Bind(Type eventType, Type conveyorType)
        {
            conveyors.Add(eventType, conveyorType);
        }

        public void Send<T>(T @event) where T : IEvent
        {
            if (conveyors.ContainsKey(typeof(T)))
            {
                var conveyorType = conveyors[typeof(T)];

                var conveyor = conveyorFactory.GetConveyorInstance<T>(conveyorType);

                conveyor.Send(@event);

                currentConveyor = conveyor;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public T Receive<T>()
        {
            return currentConveyor.Receive<T>();
        }

        public void SetConveyorFactory(IConveyorFactory factory)
        {
            conveyorFactory = factory;
        }

        public IBindEventTo<T> BindEvent<T>() where T : IEvent
        {
            return new BindEventTo<T>(this);
        }
    }
}
