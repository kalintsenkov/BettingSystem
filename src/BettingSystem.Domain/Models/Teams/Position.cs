namespace BettingSystem.Domain.Models.Teams
{
    using Common;

    public class Position : Enumeration
    {
        public static readonly Position Goalkeeper = new Position(1, nameof(Goalkeeper));
        public static readonly Position Defender = new Position(2, nameof(Defender));
        public static readonly Position Midfielder = new Position(3, nameof(Midfielder));
        public static readonly Position Forward = new Position(4, nameof(Forward));

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
