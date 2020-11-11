namespace BettingSystem.Infrastructure.Identity
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Application;
    using Application.Common;
    using Application.Contracts;
    using Application.Features.Identity;
    using Application.Features.Identity.Commands.LoginUser;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    public class IdentityService : IIdentity
    {
        private const string InvalidLoginErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly ApplicationSettings applicationSettings;

        public IdentityService(
            UserManager<User> userManager,
            IOptions<ApplicationSettings> applicationSettings)
        {
            this.userManager = userManager;
            this.applicationSettings = applicationSettings.Value;
        }

        public async Task<Result> Register(UserRequestModel userRequest)
        {
            var user = new User(userRequest.Email);

            var identityResult = await this.userManager.CreateAsync(
                user,
                userRequest.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result<LoginResponseModel>> Login(UserRequestModel userRequest)
        {
            var user = await this.userManager.FindByEmailAsync(userRequest.Email);
            if (user == null)
            {
                return InvalidLoginErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(
                user,
                userRequest.Password);

            if (!passwordValid)
            {
                return InvalidLoginErrorMessage;
            }

            var token = this.GenerateJwtToken(
                user.Id,
                user.Email);

            return new LoginResponseModel(token);
        }

        private string GenerateJwtToken(string userId, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
