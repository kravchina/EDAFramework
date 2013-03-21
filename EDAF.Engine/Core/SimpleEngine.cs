using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class SimpleEngine : ISimpleEngine
    {
        public void Execute<T>(T @event) where T : IEvent
        {
            throw new System.NotImplementedException();
        }
    }
}
