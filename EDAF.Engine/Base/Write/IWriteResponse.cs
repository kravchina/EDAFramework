using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base.Write
{
    public interface IWriteResponse
    {
        TResponse GetResponse<TResponse>();
    }
}
