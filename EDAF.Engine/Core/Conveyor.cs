﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class Conveyor<T> : IConveyor<T> where T : IEvent
    {
        protected IHandleFactory handleFactory;

        protected Conveyor(IHandleFactory handleFactory)
        {
            this.handleFactory = handleFactory;
        }

        public abstract void Run(T @event);

        protected void Handle<TK>(T @event) where TK : IHandle<T>
        {
            handleFactory.GetHandlerInstance<T>(typeof(TK)).Handle(@event);
        }
    }
}