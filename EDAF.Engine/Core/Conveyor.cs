using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class Conveyor<T> : IConveyor<T> where T : IEvent
    {
        protected IHandleFactory handleFactory;

        protected Conveyor(IHandleFactory handleFactory)
        {
            this.handleFactory = handleFactory;
        }

        protected void Handle<TK>(T @event) where TK : IHandleVoid<T>
        {
            handleFactory.GetHandlerInstance<T>(typeof(TK)).Handle(@event);
        }

        protected void Handle<TK, TResult>(T @event) where TK : IHandleVoid<T>,  IHandleResult<T, TResult>
        {
            handleFactory.GetHandlerInstance<T,TResult>(typeof(TK)).Handle(@event);
        }

        public abstract void Send(T @event);

        public virtual K Receive<K>()
        {
            throw new Exception("This conveyor not return a value");
        }
    }
}

namespace olololo
{
    public interface IEvent{}

    public class Event : IEvent{}

    public interface IHandle<T> where T : IEvent
    {
        void Handle(T @event);
    }

    public interface IHandle<T, TK> where T : IEvent
    {
        TK Handle(T @event);
    }

    public class Receiver : IHandle<Event>
    {
        public void Handle(Event @event)
        {
            throw new NotImplementedException();
        }
    }

    public class Transceiver : IHandle<Event, int>
    {
        public int Handle(Event @event)
        {
            throw new NotImplementedException();
        }
    }

    public class Conveor<T, TK> where T: IEvent
    {
        protected void Receive<TH>(T @event) where TH : IHandle<T>
        {
            
        }

        protected TK ReceiveAndTransmit<TH>(T @event) where TH : IHandle<T, TK>
        {
            
        } 
    }

    public class MyConveyor : Conveor<Event, int>
    {
        public void test()
        {
            var evnt = new Event();

            Receive<Receiver>(evnt);

            ReceiveAndTransmit<Transceiver>(evnt);
        }
    }
}