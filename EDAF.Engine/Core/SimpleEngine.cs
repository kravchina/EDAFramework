using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class SimpleEngine : ISimpleEngine
    {
        public IWriteResponse Write<T>(T @event) where T : IWriteEvent
        {
            throw new System.NotImplementedException();
        }
    }
}
