namespace BettingSystem.Infrastructure.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Bets;
    using Application.Features.Bets.Queries.Details;
    using AutoMapper;
    using Domain.Models.Bets;
    using Domain.Models.Gamblers;
    using Domain.Specifications;
    using Microsoft.EntityFrameworkCore;

    internal class BetRepository : DataRepository<Bet>, IBetRepository
    {
        private readonly IMapper mapper;

        public BetRepository(BettingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var bet = await this.Data.Bets.FindAsync(id, cancellationToken);

            if (bet == null)
            {
                return false;
            }

            this.Data.Remove(bet);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Bet> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Include(b => b.Match)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        public async Task<BetDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<BetDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(b => b.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<TResponseModel>> GetBetListings<TResponseModel>(
            Specification<Bet> betSpecification,
            Specification<Gambler> gamblerSpecification,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TResponseModel>(this
                    .GetGamblerBetsQuery(betSpecification, gamblerSpecification))
                .ToListAsync(cancellationToken);

        private IQueryable<Bet> GetGamblerBetsQuery(
            Specification<Bet> betSpecification,
            Specification<Gambler> gamblerSpecification)
            => this
                .Data
                .Gamblers
                .Where(gamblerSpecification)
                .SelectMany(g => g.Bets)
                .Where(betSpecification);
    }
}
