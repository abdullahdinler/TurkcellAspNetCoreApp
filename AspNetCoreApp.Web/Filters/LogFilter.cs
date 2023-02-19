using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreApp.Web.Filters
{
    public class LogFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action method calişmadan önce");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action method calıştıktan sonra");
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Action method sonuc üretilmeden önce");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Action method sonuc üretilidikten sonra");
        }
    }
}
