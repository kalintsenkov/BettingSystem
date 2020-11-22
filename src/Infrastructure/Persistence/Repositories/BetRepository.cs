namespace BettingSystem.Infrastructure.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Bets;
    using Application.Features.Bets.Queries.Details;
    using AutoMapper;
    using Domain.Models.Bets;
    using Microsoft.EntityFrameworkCore;

    internal class BetRepository : DataRepository<Bet>, IBetRepository
    {
        private readonly IMapper mapper;

        public BetRepository(BettingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<BetDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<BetDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(b => b.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
