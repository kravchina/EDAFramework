using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface INeed<in T>
    {
        void Inject(T obj);
    }
}
