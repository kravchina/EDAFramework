using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class SimpleEngine : ISimpleEngine
    {
        public void Send<T>(T @event) where T : IEvent
        {
            throw new System.NotImplementedException();
        }

        public T Receive<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
