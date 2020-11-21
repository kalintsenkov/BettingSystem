namespace BettingSystem.Infrastructure.Identity
{
    using Application.Features.Identity;
    using Domain.Exceptions;
    using Domain.Models.Gamblers;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Gambler? Gambler { get; private set; }

        public void BecomeGambler(Gambler gambler)
        {
            if (this.Gambler != null)
            {
                throw new InvalidGamblerException($"User '{this.UserName}' is already existing.");
            }

            this.Gambler = gambler;
        }
    }
}
