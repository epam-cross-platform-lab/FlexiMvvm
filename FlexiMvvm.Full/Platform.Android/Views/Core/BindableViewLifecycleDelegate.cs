// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using FlexiMvvm.Bindings;
using FlexiMvvm.Persistence.Core;
using FlexiMvvm.ViewModels;
using FlexiMvvm.ViewModels.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Views.Core
{
    public class BindableViewLifecycleDelegate<TView, TViewModel> : ViewLifecycleDelegate<TView, TViewModel>
        where TView : class, IBindableView<TViewModel>, IForwardNavigationView<TViewModel>, IBindingSetOwner, IViewModelOwner<TViewModel>
        where TViewModel : class, IViewModel, IStateOwner
    {
        public BindableViewLifecycleDelegate([NotNull] TView view)
            : base(view)
        {
        }

        public override void OnStart()
        {
            base.OnStart();

            if (View.BindingSet == null)
            {
                var bindingSet = new BindingSet<TViewModel>(View.ViewModel);

                View.Bind(bindingSet);
                View.SetBindingSet(bindingSet);
                bindingSet.Apply();
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            View.BindingSet?.Dispose();
            View.SetBindingSet(null);
        }
    }
}
