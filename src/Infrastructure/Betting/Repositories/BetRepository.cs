namespace BettingSystem.Infrastructure.Betting.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Betting.Bets;
    using Application.Betting.Bets.Queries.Details;
    using AutoMapper;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Betting.Models.Bets;
    using Domain.Betting.Models.Gamblers;
    using Domain.Betting.Repositories;
    using Domain.Common;
    using Microsoft.EntityFrameworkCore;

    internal class BetRepository : DataRepository<IBettingDbContext, Bet, BetData>,
        IBetDomainRepository,
        IBetQueryRepository
    {
        public BetRepository(IBettingDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var bet = await this.Data.Bets.FindAsync(id);

            if (bet == null)
            {
                return false;
            }

            this.Data.Bets.Remove(bet);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Bet> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<Bet>(this
                    .AllAsDataModels()
                    .Include(b => b.Match))
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        public async Task<BetDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken)
            => await this.Mapper
                .ProjectTo<BetDetailsResponseModel>(this
                    .AllAsDomainModels()
                    .Where(b => b.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<TResponseModel>> GetBetListings<TResponseModel>(
            Specification<Bet> betSpecification,
            Specification<Gambler> gamblerSpecification,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<TResponseModel>(this
                    .GetGamblerBetsQuery(betSpecification, gamblerSpecification))
                .ToListAsync(cancellationToken);

        private IQueryable<Bet> GetGamblerBetsQuery(
            Specification<Bet> betSpecification,
            Specification<Gambler> gamblerSpecification)
            => this
                .AllGamblers()
                .Where(gamblerSpecification)
                .SelectMany(g => g.Bets)
                .Where(betSpecification);

        private IQueryable<Gambler> AllGamblers()
            => this.Mapper
                .ProjectTo<Gambler>(this
                    .Data
                    .Gamblers
                    .AsNoTracking());
    }
}
