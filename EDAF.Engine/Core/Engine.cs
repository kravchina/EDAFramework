using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class Engine : IEngine
    {
        private readonly Dictionary<Type, Type> conveyors;

        private IConveyorFactory conveyorFactory;

        public Engine()
        {
            conveyors = new Dictionary<Type, Type>();
        }
        public void Register<T>(IConveyor<T> conveer)
            where T : IEvent
        {
            throw new NotImplementedException();
            /*conveyors.Add(typeof(T), conveer);*/
        }

        public void Bind(Type eventType, Type conveyorType)
        {
            conveyors.Add(eventType, conveyorType);
        }

        public void Execute<T>(T @event) where T : IEvent
        {
            if (conveyors.ContainsKey(typeof(T)))
            {
                var conveyorType = conveyors[typeof(T)];

                if (conveyorType == null)
                    throw new InvalidCastException();

                var conveyor = conveyorFactory.GetConveyorInstance<T>(conveyorType);

                conveyor.Run(@event);
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
    }
}
