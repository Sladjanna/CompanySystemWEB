using Model;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            User currentUser = (User)filterContext.HttpContext.Session["user"];

            if (currentUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index" }));

            }

        }
    }
}