using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IConveyorFactory
    {
        IConveyor<T> GetConveyorInstance<T>(Type conveyorType) where T : IEvent;
    }
}
