using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public interface ITestHandler
    {
        
    }

    public interface IResp<T>
    {
        
    }

    public class TestHandler : ITestHandler, IResp<int>
    {
        
    }

    public class HandlingConfig<T> where T : ITestHandler
    {
    }

    public static class HandlingConfigExt 
    {
        public static void GetResponse<K,T>(this HandlingConfig<T> t) where T : ITestHandler, IResp<K>
        {
            
        }
    }

    public class Engine : IEngine
    {

         

        private readonly IEventBinding eventBinding;

        private readonly IHandlerServiceLocator handlerServiceLocator;

        public Engine(IHandlerServiceLocator handlerServiceLocator, IEventBinding eventBinding)
        {
            new HandlingConfig<TestHandler>().GetResponse<int>();

            this.handlerServiceLocator = handlerServiceLocator;

            this.eventBinding = eventBinding;
        }

        private IHandleResponse<T> HandleEvent<T>(T @event) where T : IEvent
        {
            var units = GetHandlersUnits(typeof(T));

            var conveyor = GetConveyor<T>(units).ToList();

            IHandleResponse<T> response;

            try
            {
                response = StartHandle(@event, conveyor);

                CommitHandle(conveyor);
            }
            catch (Exception)
            {
                RollbackHandle(conveyor);

                throw;
            }
            return response;
        }

        private IHandleResponse<T> StartHandle<T>(T @event, IEnumerable<ConveyorItem<HandlerUnit, IHandle<T>>> conveyor) where T : IEvent
        {
            IHandleResponse<T> handleResponse = new NullHandleResponse<T>();
            
            foreach (var item in conveyor)
            {
                var handler = item.Handler;

                if (item.Binding.IsNeedPreviousResponse)
                {
                    var response = handleResponse.GetResponse<object>();

                    var method = handler.GetType().GetMethod("InjectResponse");

                    method.Invoke(handler, new[] { response });
                }

                handler.Handle(@event);

                if (item.Binding.IsResponse)
                    handleResponse = new HandleResponse<T>(item.Handler);
            }

            return handleResponse;
        }

        private void CommitHandle<T>(IEnumerable<ConveyorItem<HandlerUnit, IHandle<T>>> conveyor) where T : IEvent
        {
            foreach (var item in conveyor)
            {
                if (item.Binding.IsCommit)
                {
                    ((ICommit)item.Handler).Commit();
                }
            }
        }

        private void RollbackHandle<T>(IEnumerable<ConveyorItem<HandlerUnit, IHandle<T>>> conveyor) where T : IEvent
        {
            foreach (var binding in conveyor)
            {
                if (binding.Binding.IsRollback)
                {
                    ((IRollback)binding.Handler).Rollback();
                }
            }
        }

        private IEnumerable<HandlerUnit> GetHandlersUnits(Type eventType)
        {
            if (eventBinding.IsBinded(eventType))
            {
                return eventBinding.GetHandledConveyor(eventType);
            }

            throw new KeyNotFoundException();
        }

        private IEnumerable<ConveyorItem<HandlerUnit, IHandle<T>>> GetConveyor<T>(IEnumerable<HandlerUnit> units) where T : IEvent
        {
            foreach (var binding in units)
            {
                var handler = handlerServiceLocator.GetHandler<T>(binding.HandlerType);
                
                yield return new ConveyorItem<HandlerUnit, IHandle<T>>(binding, handler);
            }
        }

        public IHandleResponse<T> Handle<T>(T @event) where T : IEvent
        {
            return HandleEvent(@event);
        }
    }
}
