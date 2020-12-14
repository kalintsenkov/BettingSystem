namespace BettingSystem.Infrastructure.Betting.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Betting.Gamblers;
    using Application.Betting.Gamblers.Queries.Details;
    using AutoMapper;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Betting.Exceptions;
    using Domain.Betting.Models.Gamblers;
    using Domain.Betting.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class GamblerRepository : DataRepository<IBettingDbContext, Gambler, GamblerData>,
        IGamblerDomainRepository,
        IGamblerQueryRepository
    {
        public GamblerRepository(IBettingDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<Gambler> FindByUser(
            string userId,
            CancellationToken cancellationToken = default) 
            => this.Mapper
                .Map<GamblerData, Gambler>(await this
                    .FindByUser(
                        userId, 
                        user => user, 
                        cancellationToken));

        public async Task<int> GetGamblerId(
            string userId,
            CancellationToken cancellationToken = default)
            => await this.FindByUser(
                userId,
                user => user.Id,
                cancellationToken);

        public async Task<bool> HasBet(
            int gamblerId,
            int betId,
            CancellationToken cancellationToken = default)
            => await this
                .AllAsDataModels()
                .Where(g => g.Id == gamblerId)
                .AnyAsync(g => g.Bets
                    .Any(b => b.Id == betId), cancellationToken);

        public async Task<GamblerDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<GamblerDetailsResponseModel>(this
                    .AllAsDataModels()
                    .Where(g => g.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<GamblerData, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var gambler = await this
                .AllAsDataModels()
                .Where(u => u.UserId == userId)
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
