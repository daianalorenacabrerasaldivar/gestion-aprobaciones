namespace Domain.Common.OptionResponse
{
    public abstract class Option<TResult>
    {
        public abstract TResult Value { get; }

        protected abstract DataStatus DataStatus { get; }

        public bool hasValue => DataStatus == DataStatus.Ok;

        public bool IsNone => DataStatus == DataStatus.NullOrEmpty;

        public bool IsFailed => DataStatus == DataStatus.Failed;

        public abstract string Info { get; }

        public static implicit operator TResult(Option<TResult> @this)
        {
            return @this.Value;
        }

    }
    public enum DataStatus
    {
        Failed,
        NullOrEmpty,
        Ok
    }
}
