namespace BettingSystem.Domain.Teams.Models
{
    using Common.Models;

    public class Position : Enumeration
    {
        public static readonly Position Goalkeeper = new(0, nameof(Goalkeeper));
        public static readonly Position Defender = new(1, nameof(Defender));
        public static readonly Position Midfielder = new(2, nameof(Midfielder));
        public static readonly Position Forward = new(3, nameof(Forward));

        private Position(int value)
            : this(value, FromValue<Position>(value).Name)
        {
        }

        private Position(int value, string name)
            : base(value, name)
        {
        }
    }
}
