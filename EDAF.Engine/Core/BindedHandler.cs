using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Core
{
    public class BindedHandler
    {
        private IList<Type> needsType;

        public BindedHandler()
        {
            needsType = new List<Type>();
        }

        public Type HandlerType { get; set; }

        public bool IsResponse { get; set; }

        public void AddNeedType(Type type)
        {
            needsType.Add(type);
        }

        public bool IsNeedType(Type type)
        {
            foreach (var neededType in needsType)
            {
                if (neededType == type)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
