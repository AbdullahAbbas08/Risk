using Risk_Data_Access_Layer.Constants;

namespace Risk_Business_Layer.Seeds
{
    internal static class DefaultRoles
    {
        public static async Task SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Agent.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Client.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Customer.ToString()));
            }
        }
    }
}
