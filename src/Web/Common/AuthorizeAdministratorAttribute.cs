namespace BettingSystem.Web.Common
{
    using Microsoft.AspNetCore.Authorization;

    using static Domain.Common.Models.ModelConstants.Identity;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
