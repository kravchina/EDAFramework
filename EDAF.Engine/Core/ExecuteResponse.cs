using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public sealed class ExecuteResponse<T> : IExecuteResponse where T : IEvent
    {
        private IConveyor<T> _conveyor;

        public ExecuteResponse(IConveyor<T> conveyor)
        {
            _conveyor = conveyor;
        }

        public TResult GetResponse<TResult>()
        {
            var conveyor = _conveyor as IConveyor<T, TResult>;

            if (conveyor == null)
            {
                throw new Exception("This conveyor can not return respone or invalid requested response type");
            }

            return conveyor.GetResponse();
        }
    }
}
