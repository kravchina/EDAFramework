using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IConveyor<T> where T : IEvent
    {
        void Run(T @event);
    }
}
