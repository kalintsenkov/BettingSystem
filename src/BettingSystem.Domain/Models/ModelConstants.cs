namespace BettingSystem.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Identity
        {
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MinPasswordLength = 6;
        }
    }
}
