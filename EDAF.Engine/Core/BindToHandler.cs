using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class BindToHandler<T> : IBindToHandler<T> where T : IEvent
    {
        private readonly ICollection<BindedHandler> conveyor;

        public BindToHandler(ICollection<BindedHandler> conveyor)
        {
            this.conveyor = conveyor;
        }

        public IBindToHandler<T> ToHandler<TK>() where TK : IHandle<T>
        {
            var binding = new BindedHandler
                {
                    HandlerType = typeof(TK)
                };

            foreach (var @interface in typeof(TK).GetInterfaces())
            {
                if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IResponse<>))
                {
                    binding.IsResponse = true;
                } 
                if (@interface == typeof(IRequireUser))
                {
                    binding.IsRequiredUser = true;
                }
            }

            conveyor.Add(binding);

            return this;
        }
    }
}
