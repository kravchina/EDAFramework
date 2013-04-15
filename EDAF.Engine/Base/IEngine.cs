﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDAF.Engine.Base.Read;
using EDAF.Engine.Base.Write;

namespace EDAF.Engine.Base
{
    public interface IEngine : IWriteEngine, IReadEngine
    {
    }
}
