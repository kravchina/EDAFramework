using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        private readonly ICollection<Tuple<Type, bool>> conveyor;

        public EventBinding(ICollection<Tuple<Type, bool>> conveyor )
        {
            this.conveyor = conveyor;
        }

        public IEventBinding<T> ToHandler<TK>() where TK : IHandle<T>
        {
            bool isResponseHandler = false;

            foreach (var @interface in typeof(TK).GetInterfaces())
            {
                if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof (IResponse<>))
                {
                    isResponseHandler = true;
                    break;
                }
            }

            conveyor.Add(new Tuple<Type, bool>(typeof(TK), isResponseHandler));

            return this;
        }
    }
}
