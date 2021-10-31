namespace BettingSystem.Infrastructure.Teams.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Teams;
    using Application.Teams.Queries.All;
    using Application.Teams.Queries.Coaches;
    using Application.Teams.Queries.Players;
    using AutoMapper;
    using Common.Repositories;
    using Domain.Teams.Models;
    using Domain.Teams.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class TeamRepository : DataRepository<TeamsDbContext, Team>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        private readonly IMapper mapper;

        public TeamRepository(TeamsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var team = await this.Data.Teams.FindAsync(id);

            if (team == null)
            {
                return false;
            }

            this.Data.Teams.Remove(team);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Team?> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<Coach?> GetCoach(
            string name,
            CancellationToken cancellationToken = default)
            => await this
                .AllCoaches()
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<GetAllTeamsResponseModel>> GetTeamsListing(
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetAllTeamsResponseModel>(this
                    .AllAsNoTracking())
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<GetCoachesResponseModel>> GetCoachesListing(
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetCoachesResponseModel>(this
                    .AllCoaches())
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<GetTeamPlayersResponseModel>> GetTeamPlayersListing(
            int teamId,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetTeamPlayersResponseModel>(this
                    .AllAsNoTracking()
                    .Where(t => t.Id == teamId)
                    .SelectMany(t => t.Players))
                .ToListAsync(cancellationToken);

        private IQueryable<Coach> AllCoaches()
            => this
                .Data
                .Coaches
                .AsNoTracking();
    }
}
