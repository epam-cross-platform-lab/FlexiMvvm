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
using FlexiMvvm.Formatters;
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views.Core
{
    internal static class ViewCache
    {
        private static List<WeakReference<IView<ILifecycleViewModel>>>? _viewsWeakReferences;

        private static List<WeakReference<IView<ILifecycleViewModel>>> ViewsWeakReferences => _viewsWeakReferences ??= new List<WeakReference<IView<ILifecycleViewModel>>>();

        internal static TView Get<TView, TViewModel>(TViewModel viewModel)
            where TView : class, IView<TViewModel>
            where TViewModel : class, ILifecycleViewModel
        {
            TView? view = null;

            if (_viewsWeakReferences != null)
            {
                foreach (var viewWeakReference in _viewsWeakReferences)
                {
                    if (viewWeakReference.TryGetTarget(out var cachedView) && ReferenceEquals(cachedView.ViewModel, viewModel))
                    {
                        view = (TView)cachedView;

                        break;
                    }
                }
            }

            if (view == null)
            {
                throw new InvalidOperationException(
                    $"The view instance is missing for the provided '{TypeFormatter.FormatName(viewModel.GetType())}' view model one.");
            }

            return view;
        }

        internal static void Add(IView<ILifecycleViewModel> view)
        {
            ViewsWeakReferences.Add(new WeakReference<IView<ILifecycleViewModel>>(view));
        }

        internal static void Remove(IView<ILifecycleViewModel> view)
        {
            foreach (var viewWeakReference in ViewsWeakReferences)
            {
                if (viewWeakReference.TryGetTarget(out var cachedView) && ReferenceEquals(cachedView, view))
                {
                    ViewsWeakReferences.Remove(viewWeakReference);

                    break;
                }
            }
        }
    }
}
