using FlexiMvvm.ViewModels;

namespace NavigationFlow.Core.ViewModels.CustomFlow
{
    public sealed class CustomFlowNavigationViewModel : LifecycleViewModel, ILifecycleViewModelWithResult<FlowResult>
    {
        public void SetResult(ResultCode resultCode, FlowResult result)
        {
        }
    }
}