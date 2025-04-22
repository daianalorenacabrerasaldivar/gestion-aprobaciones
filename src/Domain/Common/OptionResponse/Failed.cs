﻿namespace Domain.Common.OptionResponse
{
    public class Failed<TResult> : Option<TResult>
    {
        private readonly TResult _value;

        private readonly string _info;

        public override TResult Value => _value;

        protected override DataStatus DataStatus => DataStatus.Failed;

        public override string Info => _info;

        public Failed(string info)
        {
            _info = info;
            _value = default;
        }
    }
}
