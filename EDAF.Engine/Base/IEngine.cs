using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IEngine
    {
        void Register<T>(IConveyor<T> conveer) where T : IEvent;
        void Bind(Type eventType, Type conveyorType);
        void Execute<T>(T @event) where T : IEvent;
        void SetConveyorFactory(IConveyorFactory factory);
    }
}
