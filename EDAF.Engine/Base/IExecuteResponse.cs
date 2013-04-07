using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IExecuteResponse
    {
        TResponse GetResponse<TResponse>();
    }
}
