using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class BindEventTo<T> : IBindEventTo<T> where T : IEvent
    {
        protected IEngine Engine;

        public BindEventTo(IEngine engine)
        {
            this.Engine = engine;
        }

        public void ToConveyor<K>() where K : IConveyor<T>
        {
            Engine.Bind(typeof(T), typeof(K));
        }
    }
}
