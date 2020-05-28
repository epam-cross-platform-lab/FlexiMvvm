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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views
{
    internal static partial class ViewRegistry
    {
        private static ConditionalWeakTable<ILifecycleViewModel, WeakReference<IView<ILifecycleViewModel>>> Registry { get; } =
            new ConditionalWeakTable<ILifecycleViewModel, WeakReference<IView<ILifecycleViewModel>>>();

        internal static bool TryGetView<TViewModel, TView>(TViewModel viewModel, [MaybeNullWhen(returnValue: false)] out TView view)
            where TViewModel : class, ILifecycleViewModel
            where TView : IView<TViewModel>
        {
            view = default;

            return Registry.TryGetValue(viewModel, out var registryViewWeakReference) &&
                registryViewWeakReference.TryGetTarget(out var registryView) &&
                (view = (TView)registryView) != null &&
                IsAlive(view);
        }

        internal static void Add(IView<ILifecycleViewModel> view)
        {
            Registry.AddOrUpdate(view.ViewModel, new WeakReference<IView<ILifecycleViewModel>>(view));
        }

        internal static void Remove(IView<ILifecycleViewModel> view)
        {
            Registry.Remove(view.ViewModel);
        }
    }
}
