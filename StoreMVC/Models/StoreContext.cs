using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebMatrix.WebData;
using System.Web.Security;
namespace StoreMVC.Models
{
    public class StoreContext :DbContext
    {
        public StoreContext()
            : base("StoreContext")
        {
            //Database.SetInitializer(new StoreContextInitializer());
        }

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<JobCategory> Categories { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobDetail> JobDetail { get; set; }
        public DbSet<JobComment> JobComments { get; set; }
        public DbSet<JobRequest> JobRequests { get; set; }
    }

    public class StoreContextInitializer : CreateDatabaseIfNotExists<StoreContext>
    {
        protected override void Seed(StoreContext context)
        
        {

            //WebSecurity.InitializeDatabaseConnection("UserContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            //if (!Roles.RoleExists("Administrator"))
            //{
            //    Roles.CreateRole("Administrator");
            //}

            //if (!WebSecurity.UserExists("Carlos"))
            //{
            //    WebSecurity.CreateUserAndAccount("Carlos", "pass123");
            //}

            //if (!Roles.GetRolesForUser("Carlos").Contains("Administrator"))
            //{
            //    Roles.AddUsersToRoles(new[] { "Carlos" }, new[] { "Administrator" });
            //}
            //if (!Roles.RoleExists("User"))
            //{
            //    Roles.CreateRole("User");
            //}

            //if (!WebSecurity.UserExists("Jose"))
            //{
            //    WebSecurity.CreateUserAndAccount("Jose", "pass123");
            //}

            //if (!Roles.GetRolesForUser("Jose").Contains("User"))
            //{
            //    Roles.AddUsersToRoles(new[] { "Jose" }, new[] { "User" });
            //}


           
            context.Categories.Add(new JobCategory() { Id = 1, Name = "Furniture", Description = "Description for furniture" });
            context.Categories.Add(new JobCategory() { Id = 2, Name = "collectibles", Description = "Description for collectibles" });
            context.Job.Add(new Job 
            { 
                Id = 1, 
                Title = "Coca cola retro", 
                Description = "Descritpion 1", 
                FileName = "cocacola.jpg",
                CategoryId = 2    
            });
            context.Job.Add(new Job
            {
                Id = 2,
                Title = "pepsi retro",
                Description = "Descritpion 2",
                FileName = "pepsi.jpg",
                CategoryId = 2
            });
            context.Job.Add(new Job
            {
                Id = 3,
                Title = "Old chair",
                Description = "Descritpion 3",
                FileName = "Image3.jpg",
                CategoryId = 1
            });

            context.JobDetail.Add(new JobDetail { JobId= 1, LongDesctiption = "Detailed desc 1.", Price = 120.00M, Finished = true });
            context.JobDetail.Add(new JobDetail { JobId= 2, LongDesctiption = "Detailed desc 2.", Price = 500.00M, Finished = true });
            context.JobDetail.Add(new JobDetail { JobId= 3, LongDesctiption = "Detailed desc. 3", Price = 320.00M, Finished = true });

            //context.JobComments.Add(new JobComment { Id=1, SubmittedBy="Carlos m", JobId = 1, Comment="Random comment", DateSubmitted = DateTime.Now });
            //context.JobComments.Add(new JobComment { Id = 2, SubmittedBy = "Carlos m", JobId = 1, Comment = "Second comment", DateSubmitted = DateTime.Now });
            //context.JobComments.Add(new JobComment { Id = 3, SubmittedBy = "Carlos m", JobId = 2, Comment = "Random comment for job 2", DateSubmitted = DateTime.Now });

            //context.JobRequests.Add(new JobRequest { Id=1, SubmittedBy="Carlos m", Email="c_23@gmail.com", Phone="6141457889", Message="new Job request ", FileName="image1.jpg" });

            context.SaveChanges();

        }

    }
}