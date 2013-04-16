using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class EventBinding : IEventBinding
    {
        private readonly IDictionary<Type, ICollection<Tuple<Type, bool>>> bindedHandler;

        public EventBinding()
        {
            bindedHandler = new Dictionary<Type, ICollection<Tuple<Type, bool>>>();
        }

        public IBindToHandler<T> BindEvent<T>() where T : IEvent
        {
            var conveyor = new LinkedList<Tuple<Type, bool>>();

            bindedHandler.Add(typeof(T), conveyor);

            return new BindToHandler<T>(conveyor);
        }

        public ICollection<Tuple<Type, bool>> GetHandledConveyor(Type eventType)
        {
            return bindedHandler[eventType];
        }

        public bool IsBinded(Type eventType)
        {
            return bindedHandler.ContainsKey(eventType);
        }
    }
}
