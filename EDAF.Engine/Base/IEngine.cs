﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDAF.Engine.Base
{
    public interface IEngine
    {
        IHandleResponse<T> Handle<T>(T @event) where T : IEvent;
        IHandleResponse<T> Handle<T, T1>(T @event, T1 arg1) where T : IEvent;
        IHandleResponse<T> Handle<T, T1, T2>(T @event, T1 arg1, T2 arg2) where T : IEvent;
        IHandleResponse<T> Handle<T, T1, T2, T3>(T @event, T1 arg1, T2 arg2, T3 arg3) where T : IEvent;
    }
}
