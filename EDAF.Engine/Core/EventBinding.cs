using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class EventBinding : IEventBinding
    {
        private readonly IDictionary<Type, ICollection<Binding>> bindedHandler;

        public EventBinding()
        {
            bindedHandler = new Dictionary<Type, ICollection<Binding>>();
        }

        public IBindToHandler<T> BindEvent<T>() where T : IEvent
        {
            var conveyor = new LinkedList<Binding>();

            bindedHandler.Add(typeof(T), conveyor);

            return new BindToHandler<T>(conveyor);
        }

        public ICollection<Binding> GetHandledConveyor(Type eventType)
        {
            return bindedHandler[eventType];
        }

        public bool IsBinded(Type eventType)
        {
            return bindedHandler.ContainsKey(eventType);
        }
    }
}
