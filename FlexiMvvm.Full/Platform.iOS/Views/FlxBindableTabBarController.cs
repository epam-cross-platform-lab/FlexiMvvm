// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public class FlxBindableTabBarController<TViewModel>
        : FlxTabBarController<TViewModel>, IBindableIosView<TViewModel>
        where TViewModel : class, IViewModelWithoutParameters
    {
        protected override IViewDelegate<FlxTabBarController> CreateViewDelegate()
        {
            return new BindableViewDelegate<FlxBindableTabBarController<TViewModel>, TViewModel>(this);
        }

        public virtual void Bind(BindingSet<TViewModel> bindingSet)
        {
        }
    }

    public class FlxBindableTabBarController<TViewModel, TParameters>
        : FlxTabBarController<TViewModel, TParameters>, IBindableIosView<TViewModel>
        where TViewModel : class, IViewModelWithParameters<TParameters>
        where TParameters : ViewModelParametersBase
    {
        public FlxBindableTabBarController([CanBeNull] TParameters parameters)
            : base(parameters)
        {
        }

        protected override IViewDelegate<FlxTabBarController> CreateViewDelegate()
        {
            return new BindableViewDelegate<FlxBindableTabBarController<TViewModel, TParameters>, TViewModel>(this);
        }

        public virtual void Bind(BindingSet<TViewModel> bindingSet)
        {
        }
    }
}
