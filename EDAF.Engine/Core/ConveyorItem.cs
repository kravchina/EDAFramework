using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Core
{
    public class ConveyorItem<TBinding, THandler>
    {
        public TBinding Binding { get; set; }

        public THandler Handler { get; set; }

        public ConveyorItem(TBinding binding, THandler handler)
        {
            Binding = binding;
            Handler = handler;
        }
    }
}
