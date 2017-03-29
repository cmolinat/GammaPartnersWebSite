using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace StoreMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            System.Data.Entity.Database.SetInitializer(new StoreContextInitializer());
            SimpleMembershipInitializer init = new SimpleMembershipInitializer();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        public class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                using (var context = new UsersContext())
                    context.UserProfiles.Find(1);

                if (!WebSecurity.Initialized)
                {
                    WebSecurity.InitializeDatabaseConnection("UserContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                    if (!Roles.RoleExists("Administrator"))
                    {
                        Roles.CreateRole("Administrator");
                    }

                    if (!WebSecurity.UserExists("admin"))
                    {
                        WebSecurity.CreateUserAndAccount("admin", "pass123");
                    }

                    if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
                    {
                        Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
                    }
                    if (!Roles.RoleExists("User"))
                    {
                        Roles.CreateRole("User");
                    }

                    if (!WebSecurity.UserExists("user"))
                    {
                        WebSecurity.CreateUserAndAccount("user", "pass123");
                    }

                    if (!Roles.GetRolesForUser("user").Contains("User"))
                    {
                        Roles.AddUsersToRoles(new[] { "user" }, new[] { "User" });
                    }
                }
            }
        }
    }
}