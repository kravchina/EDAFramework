using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Infrastructure
{
    public abstract class HandleException : Exception
    {
        public abstract int GetHttpStatus();
    }
}
