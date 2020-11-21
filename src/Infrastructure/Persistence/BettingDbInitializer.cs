namespace BettingSystem.Infrastructure.Persistence
{
    using System.Threading.Tasks;
    using Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using static InfrastructureConstants;

    internal class BettingDbInitializer : IInitializer
    {
        private readonly BettingDbContext db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public BettingDbInitializer(
            BettingDbContext db,
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

                    var adminUser = new User(AdministratorEmail);

                    await this.userManager.CreateAsync(adminUser, AdministratorPassword);
                    await this.userManager.AddToRoleAsync(adminUser, AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();
    }
}
