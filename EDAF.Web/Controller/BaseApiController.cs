using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EDAF.Engine.Base;
using EDAF.Engine.Infrastructure.ExecuteExceptions;
using EDAF.Web.Base;

namespace EDAF.Web.Controller
{
    public abstract class BaseApiController<TView, TCreate, TUpdate, TDelete, TQuery, TId, TRepository> : ApiController
        where TRepository : IRepository<TView, TQuery, TId>
        where TCreate : IEvent
        where TUpdate : IEvent
        where TDelete : IEvent
    {
        protected TRepository repository;

        protected IEngine engine;

        protected virtual HttpResponseMessage Execute(IEvent @event)
        {
            try
            {
                engine.Execute(@event);
            }
            catch (ExecuteException ex)
            {
                return Request.CreateErrorResponse(ex.GetHttpStatusCode(), ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        protected BaseApiController(IEngine engine, TRepository repository)
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

        public virtual HttpResponseMessage Post(TUpdate entity)
        {
            return Execute(entity);
        }

        public virtual HttpResponseMessage Put(TCreate entity)
        {
            return Execute(entity);
        }

        public virtual HttpResponseMessage Delete(TDelete entity)
        {
            return Execute(entity);
        }
    }
}
