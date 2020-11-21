namespace BettingSystem.Domain.Models.Bets
{
    using Common;

    public class Prediction : Enumeration
    {
        public static readonly Prediction Draw = new Prediction(0, nameof(Draw));
        public static readonly Prediction Home = new Prediction(1, nameof(Home));
        public static readonly Prediction Away = new Prediction(2, nameof(Away));

        private Prediction(int value)
            : this(value, FromValue<Prediction>(value).Name)
        {
        }

        private Prediction(int value, string name)
            : base(value, name)
        {
        }
    }
}
