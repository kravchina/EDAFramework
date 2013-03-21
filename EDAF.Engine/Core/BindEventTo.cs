using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class BindEventTo<T> : IBindEventTo<T> where T : IEvent
    {
        protected StandardEngine Engine;

        public BindEventTo(StandardEngine engine)
        {
            this.Engine = engine;
        }

        public void ToConveyor<K>() where K : IConveyor<T>
        {
            Engine.Bind(typeof(T), typeof(K));
        }
    }
}
