namespace BettingSystem.Application.Identity
{
    using Domain.Betting.Models.Gamblers;

    public interface IUser
    {
        void BecomeGambler(Gambler gambler);
    }
}
