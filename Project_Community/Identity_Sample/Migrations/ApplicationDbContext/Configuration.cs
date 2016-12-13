namespace Identity_Sample.Migrations.ApplicationDbContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity_Sample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\ApplicationDbContext";
        }

        protected override void Seed(Identity_Sample.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(userStore);


            // Create SuperAdmin Role and assign user TheAdmin to that role 
            if (!roleManager.RoleExists("SuperAdmin"))
            {

                // Create SuperAdmin Role
                var role = new IdentityRole();
                role.Name = "SuperAdmin";
                roleManager.Create(role);

                // Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "theadmin";
                user.Email = "theadmin@communitysite.net";

                string userPWD = "Password!123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");

                }
            }

            // Creating ForumModerator role    
            if (!roleManager.RoleExists("ForumModerator"))
            {
                var role = new IdentityRole();
                role.Name = "ForumModerator";
                roleManager.Create(role);

            }

            // Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }

            // Creating NormalUser role    
            if (!roleManager.RoleExists("NormalUser"))
            {
                var role = new IdentityRole();
                role.Name = "NormalUser";
                roleManager.Create(role);

            }

        }
    }
}
