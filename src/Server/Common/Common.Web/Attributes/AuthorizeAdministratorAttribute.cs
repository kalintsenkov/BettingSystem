namespace BettingSystem.Web.Common.Attributes;

using Microsoft.AspNetCore.Authorization;

using static Domain.Common.Models.ModelConstants.Common;

public class AuthorizeAdministratorAttribute : AuthorizeAttribute
{
    public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
}