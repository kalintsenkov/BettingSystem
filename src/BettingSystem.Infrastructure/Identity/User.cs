namespace BettingSystem.Infrastructure.Identity
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Models.Bets;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        private readonly HashSet<Bet> bets;

        internal User(string email)
            : base(email)
        {
            this.Email = email;

            this.bets = new HashSet<Bet>();
        }

        public IReadOnlyCollection<Bet> Bets => this.bets.ToList().AsReadOnly();

        public void AddBet(Bet bet) => this.bets.Add(bet);
    }
}
