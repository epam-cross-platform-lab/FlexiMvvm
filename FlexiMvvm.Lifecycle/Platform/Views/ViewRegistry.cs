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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views
{
    internal static partial class ViewRegistry
    {
        private static List<WeakReference<IView<ILifecycleViewModel>>> ViewsWeakReferences { get; } = new List<WeakReference<IView<ILifecycleViewModel>>>();

        internal static bool TryGetView<TViewModel, TView>(TViewModel viewModel, [MaybeNullWhen(returnValue: false)] out TView view)
            where TViewModel : class, ILifecycleViewModel
            where TView : class, IView<TViewModel>
        {
            view = default;

            for (var i = ViewsWeakReferences.Count - 1; i > -1; i--)
            {
                var viewWeakReference = ViewsWeakReferences[i];

                if (viewWeakReference.TryGetTarget(out var registryView) && IsAlive(registryView))
                {
                    if (ReferenceEquals(registryView.ViewModel, viewModel))
                    {
                        view = (TView)registryView;

                        return true;
                    }
                }
                else
                {
                    ViewsWeakReferences.Remove(viewWeakReference);
                }
            }

            return false;
        }

        internal static void Add(IView<ILifecycleViewModel> view)
        {
            ViewsWeakReferences.Add(new WeakReference<IView<ILifecycleViewModel>>(view));
        }

        internal static void Remove(IView<ILifecycleViewModel> view)
        {
            for (var i = ViewsWeakReferences.Count - 1; i > -1; i--)
            {
                var viewWeakReference = ViewsWeakReferences[i];

                if (viewWeakReference.TryGetTarget(out var registryView) && ReferenceEquals(registryView, view))
                {
                    ViewsWeakReferences.Remove(viewWeakReference);

                    break;
                }
            }
        }
    }
}
