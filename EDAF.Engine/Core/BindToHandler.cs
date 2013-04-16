using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class BindToHandler<T> : IBindToHandler<T> where T : IEvent
    {
        private readonly ICollection<Tuple<Type, bool>> conveyor;

        public BindToHandler(ICollection<Tuple<Type, bool>> conveyor )
        {
            this.conveyor = conveyor;
        }

        public IBindToHandler<T> ToHandler<TK>() where TK : IHandle<T>
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
