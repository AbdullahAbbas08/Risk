using Risk_Data_Access_Layer.Constants;

namespace Risk_Business_Layer.Seeds
{
    public static class DefaultUsers  
    {
        //public static async Task SeedAgentUser(UserManager<ApplicationUser> UserManager) 
        //{
        //    var DefaultUser = new ApplicationUser
        //    {

        //    };

        //    var user = UserManager.FindByIdAsync(DefaultUser.Id);
        //    if(user == null)
        //    {
        //        //await UserManager.CreateAsync(DefaultUser ,password );
        //        await UserManager.CreateAsync(DefaultUser);
        //        await UserManager.AddToRoleAsync(DefaultUser, Roles.Admin.ToString());

        //    }
        //}
        //public static async Task SeedAdminUser(UserManager<ApplicationUser> UserManager)
        //{
        //    var DefaultUser = new ApplicationUser
        //    { 

        //    };

        //    var user = UserManager.FindByIdAsync(DefaultUser.Id);
        //    if (user == null)
        //    {
        //        //await UserManager.CreateAsync(DefaultUser ,password );
        //        await UserManager.CreateAsync(DefaultUser);
        //        await UserManager.AddToRolesAsync(DefaultUser,new List<string> 
        //        { 
        //            Roles.Admin.ToString(),
        //            Roles.Agent.ToString(),
        //            Roles.Client.ToString(),
        //            Roles.Customer.ToString()
        //        });

        //    }

        //    //TODO Seeding Claims

        //}

        //public static async Task SeedClaimsForAdmin(this RoleManager<IdentityRole> roleManager)
        //{
        //    var AdminRole = await roleManager.FindByNameAsync(Roles.Admin.ToString())
        //}
    }
}
