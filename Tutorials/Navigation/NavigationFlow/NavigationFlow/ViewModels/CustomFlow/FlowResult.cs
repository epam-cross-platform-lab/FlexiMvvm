using FlexiMvvm.ViewModels;

namespace NavigationFlow.Core.ViewModels.CustomFlow
{
    public sealed class FlowResult : Result
    {
        public FlowResult(string value)
        {
            Value = value;
        }

        public string Value
        {
            get => Bundle.GetString();
            private set => Bundle.SetString(value);
        }
    }
}
