namespace BettingSystem.Infrastructure.Identity.Persistence;

using System.Threading.Tasks;
using Common.Persistence;
using Microsoft.AspNetCore.Identity;

using static Domain.Common.Models.ModelConstants.Common;

internal class IdentityDbInitializer : DbInitializer
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public IdentityDbInitializer(
        IdentityDbContext db,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
        : base(db)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public override void Initialize()
    {
        base.Initialize();

        this.SeedAdministrator();
    }

    private void SeedAdministrator()
        => Task
            .Run(async () =>
            {
                var existingRole = await this.roleManager.FindByNameAsync(AdministratorRoleName);

                if (existingRole != null)
                {
                    return;
                }

                var adminRole = new IdentityRole(AdministratorRoleName);

                await this.roleManager.CreateAsync(adminRole);

                var adminUser = new User("admin@bettingsystem.com");

                await this.userManager.CreateAsync(adminUser, "admin123456");
                await this.userManager.AddToRoleAsync(adminUser, AdministratorRoleName);
            })
            .GetAwaiter()
            .GetResult();
}