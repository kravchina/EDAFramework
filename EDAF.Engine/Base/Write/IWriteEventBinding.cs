using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base.Read;
using EDAF.Engine.Base.Write;

namespace EDAF.Engine.Base.Write
{
    public interface IWriteEventBinding<T> where T : IWriteEvent
    {
        IWriteEventBinding<T> ToHandler<TK>() where TK : IWriteHandler<T>;
    }

    
}
