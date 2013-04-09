using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IEngine : IWriteEngine, IReadEngine, IBindEvent
    {
        void SetConveyorFactory(IConveyorFactory factory);
    }
}
