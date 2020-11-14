namespace BettingSystem.Infrastructure.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Matches;
    using Application.Features.Matches.Queries.Details;
    using AutoMapper;
    using Domain.Models.Matches;
    using Microsoft.EntityFrameworkCore;

    internal class MatchRepository : DataRepository<Match>, IMatchRepository
    {
        private readonly IMapper mapper;

        public MatchRepository(BettingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<MatchDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<MatchDetailsResponseModel>(this
                    .All()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
