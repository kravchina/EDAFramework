using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface INeedPreviousResponse<T, K> where T : IHandleResponse<K> where K : IEvent 
    {
        void InjectResponse(IHandleResponse<K> response);
    }
}
