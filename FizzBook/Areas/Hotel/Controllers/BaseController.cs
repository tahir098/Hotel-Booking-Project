using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Controllers
{
    public class BaseController : Controller
    {
        private string theUser;

        public string TheUser
        {
            get { return theUser; }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("UserId") != null)
            {
                theUser = context.HttpContext.Session.GetString("UserId");
                base.OnActionExecuting(context);
               
            }
            else
            {
                context.Result = new RedirectToRouteResult(
                      new { area = "Hotel", controller = "Home", action = "Index" });
            }
        }
    }
}
