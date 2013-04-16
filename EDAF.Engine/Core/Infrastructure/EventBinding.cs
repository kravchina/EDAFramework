using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core.Infrastructure
{
    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        private readonly ICollection<Tuple<Type, bool>> _conveyor;


        public EventBinding(ICollection<Tuple<Type, bool>> conveyor)
        {
            _conveyor = conveyor;
        }

        public IEventBinding<T> Handle<TK>() where TK : IHandle<T>
        {
            _conveyor.Add(new Tuple<Type, bool>(typeof(TK), false));

            return this;
        }

        public IEventBinding<T> HandleAndRead<TK, TResponse>() where TK : IHandle<T>, IResponse<TResponse>
        {
            _conveyor.Add(new Tuple<Type, bool>(typeof(TK), true));

            return this;
        }
    }
}
