using System.Collections.Generic;
using System.Web.Http;
using EDAF.Engine.Base;
using EDAF.Web.Base;

namespace EDAF.Web.Controller
{
    public abstract class BaseApiController<TView, TCreate, TUpdate, TDelete, TQuery, TId, TRepository> : ApiController
        where TView : class
        where TRepository : IRepository<TView, TQuery, TId>
        where TCreate : IEvent
        where TUpdate : IEvent
        where TDelete : IEvent
    {
        protected TRepository repository;

        protected IEngine engine;

        public BaseApiController(IEngine engine, TRepository repository)
        {
            this.engine = engine;
            
            this.repository = repository;
        }

        public virtual ICollection<TView> Get([FromUri]TQuery query)
        {
            return repository.Query(query);
        }

        public virtual TView Get(TId id)
        {
            return repository.Get(id);
        }

        public virtual void Post(TUpdate entity)
        {
            engine.Execute(entity);
        }

        public virtual void Put(TCreate entity)
        {
            engine.Execute(entity);
        }

        public virtual void Delete(TDelete entity)
        {
            engine.Execute(entity);
        }
    }
}
