using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Linq;
using AspNetCoreApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly Context _context;

        public NotFoundFilter(Context context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var valueId = context.ActionArguments.Values.First();
            var id = (int) valueId;
            var hasProduct = _context.Products.Any(x => x.Id == id);
            if (hasProduct == false)
            {
                context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel(){ErrorMessages = new List<string>(){$"Id({id})'ye sahip ürün bulunamamıştır."}});
            }
        }
    }
}
