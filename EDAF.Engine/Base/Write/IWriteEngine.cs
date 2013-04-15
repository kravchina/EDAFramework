using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base.Write
{
    public interface IWriteEngine
    {
        IWriteResponse Write<T>(T @event) where T : IWriteEvent;
    }
}
