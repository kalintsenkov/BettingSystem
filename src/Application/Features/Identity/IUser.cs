namespace BettingSystem.Application.Features.Identity
{
    using Domain.Models.Gamblers;

    public interface IUser
    {
        void BecomeGambler(Gambler gambler);
    }
}
