using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IWriteConveyor<T> where T : IWriteEvent
    {
        void Run(T @event);
        IExecuteResponse GetResponse();
    }
}
