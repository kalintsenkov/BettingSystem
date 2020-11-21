namespace BettingSystem.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Gambler;
    using Domain.Exceptions;
    using Domain.Models.Gamblers;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    internal class GamblerRepository : DataRepository<Gambler>, IGamblerRepository
    {
        public GamblerRepository(BettingDbContext db)
            : base(db)
        {
        }

        public async Task<Gambler> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => await this.FindByUser(
                userId,
                user => user.Gambler!,
                cancellationToken);

        public async Task<int> GetGamblerId(
            string userId,
            CancellationToken cancellationToken = default)
            => await this.FindByUser(
                userId,
                user => user.Gambler!.Id,
                cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var gambler = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (gambler == null)
            {
                throw new InvalidGamblerException("Invalid user.");
            }

            return gambler;
        }
    }
}
