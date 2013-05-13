using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class EventBindingTuple<TBinding, THandler>
    {
        public TBinding Binding { get; set; }

        public THandler Handler { get; set; }

        public EventBindingTuple(TBinding binding, THandler handler)
        {
            Binding = binding;
            Handler = handler;
        }
    }

    public class Engine : IEngine
    {
        private readonly IEventBinding eventBinding;

        private readonly IHandlerPool handlerPool;

        public Engine(IHandlerPool handlerPool, IEventBinding eventBinding)
        {
            this.handlerPool = handlerPool;

            this.eventBinding = eventBinding;
        }

        private IHandleResponse<T> HandleEvent<T>(T @event, params Action<IHandle<T>, Binding>[] injects) where T : IEvent
        {
            var bindings = GetBindings(typeof(T));

            var conveyor = GetConveyor(bindings, injects);

            IEnumerable<IHandleResponse<T>> handleResponse;

            try
            {
                handleResponse = StartHandle(@event, conveyor);

                CommitHandle(conveyor);
            }
            catch (Exception ex)
            {
                RollbackHandle(conveyor);

                throw ex;
            }

            return handleResponse.FirstOrDefault() ?? new NullHandleResponse<T>();
        }

        private IEnumerable<HandleResponse<T>> StartHandle<T>(T @event, IEnumerable<EventBindingTuple<Binding, IHandle<T>>> conveyor) where T : IEvent
        {
            foreach (var binding in conveyor)
            {
                binding.Handler.Handle(@event);

                if (binding.Binding.IsResponse)
                    yield return new HandleResponse<T>(binding.Handler);
            }
        }

        private void CommitHandle<T>(IEnumerable<EventBindingTuple<Binding, IHandle<T>>> conveyor) where T : IEvent
        {
            foreach (var binding in conveyor)
            {
                if (binding.Binding.IsCommit)
                {
                    ((ICommit)binding.Handler).Commit();
                }
            }
        }

        private void RollbackHandle<T>(IEnumerable<EventBindingTuple<Binding, IHandle<T>>> conveyor) where T : IEvent
        {
            foreach (var binding in conveyor)
            {
                if (binding.Binding.IsRollback)
                {
                    ((IRollback)binding.Handler).Rollback();
                }
            }
        }

        private void Inject<T, TK>(TK arg, IHandle<T> handler, Binding binding) where T : IEvent
        {
            if (binding.IsNeedType(typeof(TK)))
            {
                ((INeed<TK>)handler).Inject(arg);
            }
        }

        private IEnumerable<Binding> GetBindings(Type eventType)
        {
            if (eventBinding.IsBinded(eventType))
            {
                return eventBinding.GetHandledConveyor(eventType);
            }

            throw new KeyNotFoundException();
        }

        private IEnumerable<EventBindingTuple<Binding, IHandle<T>>> GetConveyor<T>(IEnumerable<Binding> bindings, Action<IHandle<T>, Binding>[] injects) where T : IEvent
        {
            foreach (var binding in bindings)
            {
                var handler = handlerPool.GetHandler<T>(binding.HandlerType);

                foreach (var inject in injects)
                {
                    inject(handler, binding);
                }

                yield return new EventBindingTuple<Binding, IHandle<T>>(binding, handler);
            }
        }

        public IHandleResponse<T> Handle<T>(T @event) where T : IEvent
        {
            return HandleEvent(@event);
        }

        public IHandleResponse<T> Handle<T, T1>(T @event, T1 arg1) where T : IEvent
        {
            return HandleEvent(
                @event,
                (handler, binding) => Inject(arg1, handler, binding));
        }

        public IHandleResponse<T> Handle<T, T1, T2>(T @event, T1 arg1, T2 arg2) where T : IEvent
        {
            return HandleEvent(
                @event,
                (handler, binding) => Inject(arg1, handler, binding),
                (handler, binding) => Inject(arg2, handler, binding));
        }

        public IHandleResponse<T> Handle<T, T1, T2, T3>(T @event, T1 arg1, T2 arg2, T3 arg3) where T : IEvent
        {
            return HandleEvent(
                @event,
                (handler, binding) => Inject(arg1, handler, binding),
                (handler, binding) => Inject(arg2, handler, binding),
                (handler, binding) => Inject(arg3, handler, binding));
        }

        public IHandleResponse<T> Handle<T, T1, T2, T3, T4>(T @event, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where T : IEvent
        {
            return HandleEvent(
               @event,
               (handler, binding) => Inject(arg1, handler, binding),
               (handler, binding) => Inject(arg2, handler, binding),
               (handler, binding) => Inject(arg3, handler, binding),
               (handler, binding) => Inject(arg4, handler, binding));
        }

        public IHandleResponse<T> Handle<T, T1, T2, T3, T4, T5>(T @event, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where T : IEvent
        {
            return HandleEvent(
               @event,
               (handler, binding) => Inject(arg1, handler, binding),
               (handler, binding) => Inject(arg2, handler, binding),
               (handler, binding) => Inject(arg3, handler, binding),
               (handler, binding) => Inject(arg4, handler, binding),
               (handler, binding) => Inject(arg5, handler, binding));
        }

        public IHandleResponse<T> Handle<T, T1, T2, T3, T4, T5, T6>(T @event, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where T : IEvent
        {
            return HandleEvent(
               @event,
               (handler, binding) => Inject(arg1, handler, binding),
               (handler, binding) => Inject(arg2, handler, binding),
               (handler, binding) => Inject(arg3, handler, binding),
               (handler, binding) => Inject(arg4, handler, binding),
               (handler, binding) => Inject(arg5, handler, binding),
               (handler, binding) => Inject(arg6, handler, binding));
        }
    }
}
