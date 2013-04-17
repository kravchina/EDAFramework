using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web.Http;

namespace EDAF.Web.Controller
{
    public class EdafApiController<TPrincipal> : ApiController where TPrincipal : class, IPrincipal 
    {
        public new TPrincipal User
        {
            get { return base.User as TPrincipal; }
        }
    }
}
