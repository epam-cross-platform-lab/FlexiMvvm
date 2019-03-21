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
        private static List<WeakReference<IView<IViewModel>>>? _viewsWeakReferences;

        private static List<WeakReference<IView<IViewModel>>> ViewsWeakReferences =>
            _viewsWeakReferences ?? (_viewsWeakReferences = new List<WeakReference<IView<IViewModel>>>());

        internal static TView Get<TView, TViewModel>(TViewModel viewModel)
            where TView : class, IView<TViewModel>
            where TViewModel : class, IViewModel
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
                    $"View instance is missing for '{TypeFormatter.FormatName(viewModel.GetType())}' view model instance.");
            }

            return view;
        }

        internal static void Add(IView<IViewModel> view)
        {
            ViewsWeakReferences.Add(new WeakReference<IView<IViewModel>>(view));
        }

        internal static void Remove(IView<IViewModel> view)
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
