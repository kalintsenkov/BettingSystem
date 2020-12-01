namespace BettingSystem.Domain.Betting.Models.Matches
{
    using Common.Models;

    public class Status : Enumeration
    {
        public static readonly Status NotStarted = new Status(0, nameof(NotStarted));
        public static readonly Status InPlay = new Status(1, nameof(InPlay));
        public static readonly Status Finished = new Status(2, nameof(Finished));
        public static readonly Status Cancelled = new Status(3, nameof(Cancelled));

        private Status(int value)
            : this(value, FromValue<Status>(value).Name)
        {
        }

        private Status(int value, string name)
            : base(value, name)
        {
        }
    }
}
