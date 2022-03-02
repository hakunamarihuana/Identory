using System;

namespace Identory
{
    public struct IdentoryOption<SuccessType, FailType>
    {
        private SuccessType successValue;
        private FailType failValue;
        private readonly bool isSuccessful;

        public bool IsSome => isSuccessful;

        public bool IsNone => !isSuccessful;

        public SuccessType Value
        {
            get
            {
                if (!isSuccessful) throw new NullReferenceException();
                return successValue;
            }
        }

        public static IdentoryOption<SuccessType, FailType> Error(FailType value) => new IdentoryOption<SuccessType, FailType>(value);

        public static IdentoryOption<SuccessType, FailType> Successful(SuccessType value) => new IdentoryOption<SuccessType, FailType>(value);


        private IdentoryOption(SuccessType value)
        {
            successValue = value;
            failValue = default;
            isSuccessful = true;
        }

        private IdentoryOption(FailType value)
        {
            failValue = value;
            successValue = default;
            isSuccessful = false;
        }

        public TResult Match<TResult>(Func<SuccessType, TResult> requestSuccessful, Func<FailType, TResult> requestError) =>
            isSuccessful ? requestSuccessful(successValue) : requestError(failValue);
        public void Match(Action<SuccessType> requestSuccessful, Action<FailType> requestError)
        {
            if (isSuccessful)
                requestSuccessful(successValue);
            else
                requestError(failValue);
        }
            
        public override int GetHashCode() =>
            isSuccessful ? successValue.GetHashCode() : 0;
    }
}
