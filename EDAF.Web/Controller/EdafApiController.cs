using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http;
using EDAF.Engine.Base;

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
            this.engine = engine;
        }
    }
}
