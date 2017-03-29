//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Threading;
//using System.Web.Mvc;
//using WebMatrix.WebData;
//using StoreMVC.Models;
//using System.Web.Security;

//namespace StoreMVC.Filters
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
//    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
//    {
//        private static SimpleMembershipInitializer _initializer;
//        private static object _initializerLock = new object();
//        private static bool _isInitialized;

//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//    {
//        // Ensure ASP.NET Simple Membership is initialized only once per app start
//            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
//    }

//    private class SimpleMembershipInitializer
//    {
//        public SimpleMembershipInitializer()
//        {
//            Database.SetInitializer<UsersContext>(null);

//            try
//            {
//                using (var context = new UsersContext())
//                {
//                    if (!context.Database.Exists())
//                    {
//                        // Create the SimpleMembership database without Entity Framework migration schema
//                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
//                    }
//                }

//                //WebSecurity.InitializeDatabaseConnection("UserContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);

//                //if (!Roles.RoleExists("Administrator"))
//                //{
//                //    Roles.CreateRole("Administrator");
//                //}

//                //if (!WebSecurity.UserExists("Carlos"))
//                //{
//                //    WebSecurity.CreateUserAndAccount("Carlos", "pass123");
//                //}

//                //if (!Roles.GetRolesForUser("Carlos").Contains("Administrator"))
//                //{
//                //    Roles.AddUsersToRoles(new[] { "Carlos" }, new[] { "Administrator" });
//                //}


//            }
//            catch (Exception ex)
//            {
//                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
//            }
//        }
//    }
//}
//}
