namespace HarryStoreApp.Migrations
{
    using HarryStoreApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HarryStoreApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HarryStoreApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var UserStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(UserStore);
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var rolemanager = new RoleManager<IdentityRole>(roleStore);
            //await rolemanager.CreateAsync(new IdentityRole("CanManageCustomers"));
            //await UserManager.AddToRoleAsync(user.Id, "CanManageCustomers");  

            ApplicationUser User = new ApplicationUser()
            {
                Email = "Tochi@gmail.com",
                UserName = "Tochi@gmail.com",
                EmailConfirmed = true
            };
            IdentityResult result = UserManager.Create(User, "Tochi>.9999");
           if (result.Succeeded)
            {
                if (!rolemanager.RoleExists("AddCustomer"))
                {
                    var role = new IdentityRole();
                    role.Name = "AddCustomer";
                    rolemanager.Create(role);
                    UserManager.AddToRole(User.Id, "AddCustomer");

                }
                UserManager.AddToRole(User.Id, "AddCustomer");
            }
        }
    }
}
