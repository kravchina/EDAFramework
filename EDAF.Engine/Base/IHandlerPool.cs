﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IHandlerPool
    {
        IHandle<T> GetHandler<T>(Type handler) where T : IEvent;
    }
}
