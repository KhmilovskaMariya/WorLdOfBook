using Data;
using System;
using System.Data.Entity.Infrastructure;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebMatrix.Data;

namespace OnlineLibrary
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new InitializeSimpleMembershipAttribute());
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                System.Data.Entity.Database.SetInitializer<LibraryContext>(null);

                try
                {
                    using (var context = new LibraryContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class DenyAttribute : AuthorizeAttribute
        {
            public virtual string ErrorViewName { get; set; }

            public new virtual string Roles { get; set; }

            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Account" && filterContext.ActionDescriptor.ActionName == "LogOff")
                {
                    return;
                }
                IPrincipal user = filterContext.HttpContext.User;
                if (user.IsInRole(Roles))
                {
                    if (user.Identity.IsAuthenticated)
                    {
                        filterContext.HttpContext.GetOwinContext().Authentication.SignOut();
                    }
                    HandleUnauthorizedRequest(filterContext);
                }
            }

            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                if (!string.IsNullOrEmpty(ErrorViewName))
                {
                    filterContext.Result = new ViewResult() { ViewName = ErrorViewName };
                }
                else
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
        }
    }
}
