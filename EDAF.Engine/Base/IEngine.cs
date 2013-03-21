using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IEngine
    {
        void Execute<T>(T @event) where T : IEvent;
    }
}
