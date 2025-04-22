namespace Domain.Common.OptionResponse
{
    public class Success<TResult> : Option<TResult>
    {
        private readonly TResult _value;

        public override TResult Value => _value;

        protected override DataStatus DataStatus => DataStatus.Ok;

        public override string Info => "Success";

        public Success(TResult value)
        {
            _value = value;
        }
    }
}
