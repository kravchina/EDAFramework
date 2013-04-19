using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http;
using EDAF.Engine.Base;
using EDAF.Engine.Infrastructure;

namespace EDAF.Web.Controller
{
    public class EdafApiController<TPrincipal> : ApiController where TPrincipal : class, IPrincipal
    {
        protected readonly IEngine engine;

        public new TPrincipal User
        {
            get { return base.User as TPrincipal; }
        }

        public EdafApiController(IEngine engine)
        {
            engine.SetUser(User);

            this.engine = engine;
        }

        protected IHandleResponse<T> Handle<T>(T @event) where T : IEvent
        {
            try
            {
                return engine.Handle(@event);
            }
            catch (HandleException exception)
            {
                throw new HttpException(exception.GetHttpStatus(), exception.Message);
            }
            catch (Exception exception)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}
