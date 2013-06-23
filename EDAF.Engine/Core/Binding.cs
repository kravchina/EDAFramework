using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Core
{
    public class Binding
    {
        protected readonly IList<Type> NeedsType;

        public Binding()
        {
            NeedsType = new List<Type>();
        }

        public Type HandlerType { get; set; }

        public bool IsResponse { get; set; }

        public bool IsCommit { get; set; }

        public bool IsRollback { get; set; }

        public bool IsNeedPreviousResponse { get; set; }

        public void AddNeedType(Type type)
        {
            NeedsType.Add(type);
        }

        public bool IsNeedType(Type type)
        {
            return NeedsType.Any(neededType => neededType == type);
        }
    }
}
