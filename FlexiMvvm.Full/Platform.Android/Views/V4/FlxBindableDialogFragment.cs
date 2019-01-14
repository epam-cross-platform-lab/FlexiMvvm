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
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views.Core;

namespace FlexiMvvm.Views.V4
{
    public class FlxBindableDialogFragment<TViewModel> : FlxDialogFragment<TViewModel>, IBindableAndroidView<TViewModel>
        where TViewModel : class, IViewModelWithoutParameters, IViewModelWithState
    {
        protected override IViewDelegate<FlxDialogFragment> CreateViewDelegate()
        {
            return new BindableViewDelegate<FlxBindableDialogFragment<TViewModel>, TViewModel>(this);
        }

        public virtual void Bind(BindingSet<TViewModel> bindingSet)
        {
        }
    }

    public class FlxBindableDialogFragment<TViewModel, TParameters> : FlxDialogFragment<TViewModel, TParameters>, IBindableAndroidView<TViewModel>
        where TViewModel : class, IViewModelWithParameters<TParameters>, IViewModelWithState
        where TParameters : ViewModelParametersBase
    {
        protected override IViewDelegate<FlxDialogFragment> CreateViewDelegate()
        {
            return new BindableViewDelegate<FlxBindableDialogFragment<TViewModel, TParameters>, TViewModel>(this);
        }

        public virtual void Bind(BindingSet<TViewModel> bindingSet)
        {
        }
    }
}
