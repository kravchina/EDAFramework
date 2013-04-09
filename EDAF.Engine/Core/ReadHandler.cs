using EDAF.Engine.Base;

namespace EDAF.Engine.Core
{
    public abstract class ReadHandler<T, TResult> : IReadHandler<T, TResult> where T : IReadEvent<TResult>
    {
        public virtual TResult Handle(T @event)
        {
            var preEvent = PreRequest(@event);

            var result = Request(preEvent);

            return PostRequest(preEvent, result);
        }

        public virtual T PreRequest(T @event)
        {
            return @event;
        }

        public abstract TResult Request(T @event);

        public virtual TResult PostRequest(T @event, TResult result)
        {
            return result;
        }
    }
}
