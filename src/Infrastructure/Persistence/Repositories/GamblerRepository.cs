namespace BettingSystem.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Gambler;
    using Application.Features.Gambler.Queries.Details;
    using AutoMapper;
    using Domain.Exceptions;
    using Domain.Models.Gamblers;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    internal class GamblerRepository : DataRepository<Gambler>, IGamblerRepository
    {
        private readonly IMapper mapper;

        public GamblerRepository(BettingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

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

        public async Task<GamblerDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GamblerDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(g => g.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

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
