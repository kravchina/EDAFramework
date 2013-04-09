using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EDAF.Engine.Base;

namespace EDAF.Web.Controller
{
    public class BaseController : System.Web.Mvc.Controller
    {
        protected IWriteEngine engine;

        protected ActionResult Execute(IWriteEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
