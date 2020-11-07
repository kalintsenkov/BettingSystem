namespace BettingSystem.Application.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Result
    {
        private readonly IEnumerable<string> errors;

        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            this.Succeeded = succeeded;
            this.errors = errors;
        }

        public bool Succeeded { get; }

        public IEnumerable<string> Errors
            => this.Succeeded
                ? Enumerable.Empty<string>()
                : this.errors;

        public static Result Success
            => new Result(true, Enumerable.Empty<string>());

        public static Result Failure(IEnumerable<string> errors)
            => new Result(false, errors);

        public static implicit operator Result(string error)
            => Failure(new[] { error });

        public static implicit operator Result(string[] errors)
            => Failure(errors);

        public static implicit operator Result(List<string> errors)
            => Failure(errors);

        public static implicit operator Result(bool success)
            => success ? Success : Failure(Enumerable.Empty<string>());
    }

    public class Result<TData> : Result
    {
        private readonly TData data;

        private Result(bool succeeded, TData data, IEnumerable<string> errors)
            : base(succeeded, errors)
            => this.data = data;

        public TData Data
            => this.Succeeded
                ? this.data
                : throw new InvalidOperationException(
                    $"{nameof(this.Data)} is not available with a failed result. Use {this.Errors} instead.");

        public static Result<TData> SuccessWith(TData data)
            => new Result<TData>(true, data, Enumerable.Empty<string>());

        public new static Result<TData> Failure(IEnumerable<string> errors)
            => new Result<TData>(false, default!, errors);

        public static implicit operator Result<TData>(string error)
            => Failure(new[] { error });

        public static implicit operator Result<TData>(string[] errors)
            => Failure(errors);

        public static implicit operator Result<TData>(List<string> errors)
            => Failure(errors);

        public static implicit operator Result<TData>(TData data)
            => SuccessWith(data);
    }
}
