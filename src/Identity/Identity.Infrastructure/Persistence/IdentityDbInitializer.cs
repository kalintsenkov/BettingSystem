namespace BettingSystem.Infrastructure.Identity.Persistence
{
    using System.Threading.Tasks;
    using Common;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class IdentityDbInitializer : IInitializer
    {
        private readonly IdentityDbContext db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDbInitializer(
            IdentityDbContext db,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();

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
}
