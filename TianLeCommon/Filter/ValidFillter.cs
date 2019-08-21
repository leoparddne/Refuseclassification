using Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TianLeCommon.Filter
{
    public class ValidFillter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                foreach (var key in modelState.Keys)
                {
                    var modelstate = modelState[key];
                    if (modelstate.Errors.Any())
                    {
                        var err = modelstate.Errors.FirstOrDefault().ErrorMessage;
                        throw new RequestException((RetCode)Enum.Parse(typeof(RetCode), err));
                    }
                }
            }
        }
    }
}
