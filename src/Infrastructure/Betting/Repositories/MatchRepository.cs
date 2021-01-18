namespace BettingSystem.Infrastructure.Betting.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Betting.Matches;
    using AutoMapper;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Betting.Models.Matches;
    using Domain.Betting.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class MatchRepository : DataRepository<IBettingDbContext, Match, MatchData>,
        IMatchDomainRepository,
        IMatchQueryRepository
    {
        public MatchRepository(IBettingDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<Match> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<Match>(this
                    .AllAsDataModels()
                    .Where(m => m.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
