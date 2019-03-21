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

using System;
using FlexiMvvm.Formatters;
using FlexiMvvm.Persistence;
using FlexiMvvm.Persistence.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public abstract class ViewModelFactory : IViewModelFactory
    {
        [NotNull]
        protected abstract TViewModel CreateInstance<TViewModel>()
            where TViewModel : class, ILifecycleViewModel;

        public TViewModel Create<TViewModel>()
            where TViewModel : class, ILifecycleViewModel
        {
            var viewModel = CreateInstance<TViewModel>();

            if (viewModel == null)
            {
                throw new InvalidOperationException(
                    $"\"{TypeFormatter.FormatName(GetType())}\" returned \"null\" for the \"{TypeFormatter.FormatName<TViewModel>()}>\" view model instance.");
            }

            return viewModel;
        }

        public TViewModel Create<TViewModel>(IBundle state)
            where TViewModel : class, ILifecycleViewModel, IStateOwner
        {
            var viewModel = Create<TViewModel>();
            viewModel.ImportState(state);

            return viewModel;
        }
    }
}
