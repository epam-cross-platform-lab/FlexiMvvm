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

using System;
using System.Collections.Generic;
using System.Linq;
using FlexiMvvm.Diagnostics;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views.Core
{
    internal static class ViewModelViewCache
    {
        [NotNull]
        private static readonly Dictionary<WeakReference, WeakReference> Cache = new Dictionary<WeakReference, WeakReference>();

        [NotNull]
        internal static TView GetView<TViewModel, TView>([NotNull] TViewModel viewModel)
            where TViewModel : class, IViewModel
            where TView : class, IView<TViewModel>
        {
            TView view = default;

            for (var i = 0; i < Cache.Count;)
            {
                var cacheItem = Cache.ElementAt(i);
                var cachedViewModelWeakReference = cacheItem.Key.NotNull();
                var cachedViewModel = cachedViewModelWeakReference.Target;

                if (cachedViewModel != null)
                {
                    if (ReferenceEquals(cachedViewModel, viewModel))
                    {
                        var cachedViewWeakReference = cacheItem.Value.NotNull();
                        var cachedView = cachedViewWeakReference.Target;

                        if (cachedView is TView typedCachedView)
                        {
                            view = typedCachedView;
                            break;
                        }

                        throw new InvalidOperationException($"Unable to cast view of \"{LogFormatter.FormatTypeName(cachedView)}\" type to " +
                            $"\"{LogFormatter.FormatTypeName<TView>()}\" requested one for \"{LogFormatter.FormatTypeName(viewModel)}\" view model.");
                    }

                    i++;
                }
                else
                {
                    Cache.Remove(cachedViewModelWeakReference);
                }
            }

            if (view == null)
            {
                throw new InvalidOperationException($"Unable to find a view instance for \"{LogFormatter.FormatTypeName(viewModel)}\" view model.");
            }

            return view;
        }

        internal static void Add<TViewModel, TView>([NotNull] TViewModel viewModel, [NotNull] TView view)
            where TViewModel : class, IViewModel
            where TView : class, IView<TViewModel>
        {
            var viewModelWeakReference = new WeakReference(viewModel);
            var viewWeakReference = new WeakReference(view);

            Cache[viewModelWeakReference] = viewWeakReference;
        }
    }
}
