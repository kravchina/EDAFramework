using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAF.Engine.Base
{
    public interface IBindEventTo<T> where T : IEvent
    {
        void ToConveyor<K>() where K : IConveyor<T>;
    }
}
