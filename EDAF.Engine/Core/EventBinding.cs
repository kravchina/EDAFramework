using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class EventBinding : IEventBinding
    {
        private readonly IDictionary<Type, ICollection<HandlerUnit>> bindedHandler;

        public EventBinding()
        {
            bindedHandler = new Dictionary<Type, ICollection<HandlerUnit>>();
        }

        public IBindToHandler<T> BindEvent<T>() where T : IEvent
        {
            var conveyor = new LinkedList<HandlerUnit>();

            bindedHandler.Add(typeof(T), conveyor);

            return new BindToHandler<T>(conveyor);
        }

        public ICollection<HandlerUnit> GetHandledConveyor(Type eventType)
        {
            return bindedHandler[eventType];
        }

        public bool IsBinded(Type eventType)
        {
            return bindedHandler.ContainsKey(eventType);
        }
    }
}
