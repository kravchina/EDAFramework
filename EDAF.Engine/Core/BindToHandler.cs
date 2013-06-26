using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class BindToHandler<T> : IBindToHandler<T> where T : IEvent
    {
        private readonly ICollection<Binding> conveyor;

        public BindToHandler(ICollection<Binding> conveyor)
        {
            this.conveyor = conveyor;
        }

        public IBindToHandler<T> ToHandler<TK>() where TK : IHandle<T>
        {
            var binding = new Binding
                {
                    HandlerType = typeof(TK),
                };

            foreach (var @interface in typeof(TK).GetInterfaces())
            {
                if (@interface.IsGenericType)
                {
                    if (@interface.GetGenericTypeDefinition() == typeof (IResponse<>))
                    {
                        binding.IsResponse = true;
                    }
                    else if (@interface.GetGenericTypeDefinition() == typeof(INeedPreviousResponse<>))
                    {
                        binding.IsNeedPreviousResponse = true;

                        binding.NeedPreviousResponseType = @interface.GetGenericArguments().First();
                    }
                } 
                else
                {
                    if (@interface == typeof(ICommit))
                    {
                        binding.IsCommit = true;
                    }
                    if(@interface == typeof(IRollback))
                    {
                        binding.IsRollback = true;
                    }
                } 

            }

            conveyor.Add(binding);

            return this;
        }
    }
}
