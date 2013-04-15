using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base.Write
{
    public interface IWriteHandlerPool
    {
        IWriteHandler<T> GetHandler<T>(Type type) where T : IWriteEvent;
    }
}
