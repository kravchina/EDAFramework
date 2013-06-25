using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface INeedPreviousResponse<in T>
    {
        void InjectResponse(T response);
    }
}
