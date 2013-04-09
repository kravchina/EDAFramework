using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public class BindEventTo<T> : IBindEventTo<T> where T : IWriteEvent
    {
        protected Engine Engine;

        public BindEventTo(Engine engine)
        {
            this.Engine = engine;
        }

        public void ToConveyor<K>() where K : IWriteConveyor<T>
        {
            Engine.Bind(typeof(T), typeof(K));
        }
    }
}
