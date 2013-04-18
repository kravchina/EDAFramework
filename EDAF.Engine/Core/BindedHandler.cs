using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Core
{
    public class BindedHandler
    {
        public Type HandlerType { get; set; }

        public bool IsResponse { get; set; }

        public bool IsRequiredUser { get; set; }
    }
}
