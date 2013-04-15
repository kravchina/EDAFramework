using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base.Infrastructure;
using EDAF.Engine.Base.Read;
using EDAF.Engine.Base.Write;

namespace EDAF.Engine.Core.Infrastructure
{
    public class WriteEventBinding<T> : IWriteEventBinding<T> where T : IWriteEvent
    {
        private readonly ICollection<Type> _conveyor;


        public WriteEventBinding(ICollection<Type> conveyor)
        {
            _conveyor = conveyor;
        }

        public IWriteEventBinding<T> ToHandler<TK>() where TK : IWriteHandler<T>
        {
            _conveyor.Add(typeof(TK));

            return this;
        }
    }

    public class ReadEventBinding<TRequest, TResponse> : IReadEventBinding<TRequest, TResponse> where TRequest : IReadEvent<TResponse>
    {
        private Type _handler;


        public ReadEventBinding()
        {
            throw new NotImplementedException();
        }


        public void ToHandler<TK>() where TK : IReadHandler<TRequest, TResponse>
        {
            _handler = typeof(TK);
        }
    }
}
