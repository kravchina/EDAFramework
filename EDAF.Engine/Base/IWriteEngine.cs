using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IWriteEngine
    {
        IExecuteResponse Write<T>(T @event) where T : IWriteEvent;
    }
}
