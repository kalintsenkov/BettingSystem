namespace BettingSystem.Domain.Models.Matches
{
    using Common;

    public class Result : Enumeration
    {
        public static readonly Result Draw = new Result(0, nameof(Draw));
        public static readonly Result Home = new Result(1, nameof(Home));
        public static readonly Result Away = new Result(2, nameof(Away));
        public static readonly Result NotFinished = new Result(3, nameof(NotFinished));

        private Result(int value)
            : this(value, FromValue<Result>(value).Name)
        {
        }

        private Result(int value, string name)
            : base(value, name)
        {
        }
    }
}
