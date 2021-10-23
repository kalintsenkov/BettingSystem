namespace BettingSystem.Infrastructure.Games.Repositories
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Application.Games.Teams;
    using Common.Repositories;
    using Domain.Games.Models.Teams;
    using Domain.Games.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class TeamRepository : DataRepository<GamesDbContext, Team>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        public TeamRepository(GamesDbContext db)
            : base(db)
        {
        }

        public async Task<Team?> Find(
            string team,
            CancellationToken cancellationToken = default)
            => await this
                .AllAsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == team, cancellationToken);

        public async Task<Team?> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        public async Task<Stream?> GetThumbnailLogo(
            int teamId,
            CancellationToken cancellationToken = default)
            => await this.GetLogo(
                teamId,
                team => team.Logo.ThumbnailContent,
                cancellationToken);

        public async Task<Stream?> GetOriginalLogo(
            int teamId,
            CancellationToken cancellationToken = default)
            => await this.GetLogo(
                teamId,
                team => team.Logo.OriginalContent,
                cancellationToken);

        private async Task<Stream?> GetLogo(
            int teamId,
            Expression<Func<Team, byte[]>> logoSelector,
            CancellationToken cancellationToken = default)
        {
            var teamLogo = await this
                .AllAsNoTracking()
                .Where(t => t.Id == teamId)
                .Select(logoSelector)
                .FirstOrDefaultAsync(cancellationToken);

            if (teamLogo == null)
            {
                throw new NotFoundException(nameof(Team), teamId);
            }

            return new MemoryStream(teamLogo);
        }
    }
}
