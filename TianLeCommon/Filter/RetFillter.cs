using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TianLeCommon.Filter
{
    public class RetFillter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception!=null)
            {
                if(context.Exception is RequestException ex)
                {
                    context.Result = new ObjectResult(new Ret((RetCode)ex.e));
                }
                else
                {
                    context.Result = new ObjectResult(new Ret(RetCode.ERROR));
                }
                context.ExceptionHandled = true;//停止后续异常捕获
            }
            else
            {
                if(context.Result is ObjectResult)
                {
                    var value = ((ObjectResult)context.Result).Value;
                    switch (value)
                    {
                        case RetPagedData pageData:
                            context.Result = new ObjectResult(new RetPagedData(pageData.data, pageData.page, pageData.pageSize, pageData.total));
                            break;
                        default:
                            context.Result = new ObjectResult(new Ret(value));
                            break;
                    }
                }
                else
                {
                    context.Result = new ObjectResult(new Ret());
                }
            }
           
            base.OnActionExecuted(context);
        }
    }
}
