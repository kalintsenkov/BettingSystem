namespace BettingSystem.Application.Features.Gambler.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GamblerDetailsQuery : IRequest<GamblerDetailsResponseModel>
    {
        public int Id { get; set; }

        public class GamblerDetailsQueryHandler : IRequestHandler<GamblerDetailsQuery, GamblerDetailsResponseModel>
        {
            private readonly IGamblerRepository gamblerRepository;

            public GamblerDetailsQueryHandler(IGamblerRepository gamblerRepository)
                => this.gamblerRepository = gamblerRepository;

            public async Task<GamblerDetailsResponseModel> Handle(
                GamblerDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.gamblerRepository.GetDetails(
                    request.Id,
                    cancellationToken);
        }
    }
}
