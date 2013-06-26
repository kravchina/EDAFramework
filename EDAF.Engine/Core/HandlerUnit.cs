using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Core
{
    public class HandlerUnit
    {
        public HandlerUnit()
        {
        }

        public Type HandlerType { get; set; }

        public bool IsResponse { get; set; }

        public bool IsCommit { get; set; }

        public bool IsRollback { get; set; }

        public bool IsNeedPreviousResponse { get; set; }

        public Type NeedPreviousResponseType { get; set; }
    }
}
