using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EDAF.Web.Base;

namespace EDAF.Web.Extensions
{
    public class ExecuteResult : IExecuteResult
    {
        public ExecuteResult IfSuccess(Func<ActionResult> success)
        {
            return this;
        }

        public ExecuteResult IfError(Func<ActionResult> error)
        {
            return this;
        }

        public ActionResult ToActionResult()
        {
            return new EmptyResult();
        }
    }
}
