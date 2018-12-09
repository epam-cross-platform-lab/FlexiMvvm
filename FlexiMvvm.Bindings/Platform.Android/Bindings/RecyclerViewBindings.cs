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
using Android.Support.V7.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class RecyclerViewBindings
    {
        /// <summary>
        /// Binding on <see cref="RecyclerView.ChildViewAttachedToWindow"/> event.
        /// </summary>
        /// <param name="recyclerViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="RecyclerView.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="RecyclerView.ChildViewAttachedToWindow"/> event.</returns>
        /// <exception cref="ArgumentNullException">recyclerViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<RecyclerView, object> ChildViewAttachedToWindowBinding(
            [NotNull] this IItemReference<RecyclerView> recyclerViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (recyclerViewReference == null)
                throw new ArgumentNullException(nameof(recyclerViewReference));

            return new TargetItemOneWayToSourceCustomBinding<RecyclerView, object, RecyclerView.ChildViewAttachedToWindowEventArgs>(
                recyclerViewReference,
                (recyclerView, eventHandler) => recyclerView.NotNull().ChildViewAttachedToWindow += eventHandler,
                (recyclerView, eventHandler) => recyclerView.NotNull().ChildViewAttachedToWindow -= eventHandler,
                (recyclerView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        recyclerView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (recyclerView, eventArgs) => null,
                () => "ChildViewAttachedToWindow");
        }

        /// <summary>
        /// Binding on <see cref="RecyclerView.ChildViewDetachedFromWindow"/> event.
        /// </summary>
        /// <param name="recyclerViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="RecyclerView.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="RecyclerView.ChildViewDetachedFromWindow"/> event.</returns>
        /// <exception cref="ArgumentNullException">recyclerViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<RecyclerView, object> ChildViewDetachedFromWindowBinding(
            [NotNull] this IItemReference<RecyclerView> recyclerViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (recyclerViewReference == null)
                throw new ArgumentNullException(nameof(recyclerViewReference));

            return new TargetItemOneWayToSourceCustomBinding<RecyclerView, object, RecyclerView.ChildViewDetachedFromWindowEventArgs>(
                recyclerViewReference,
                (recyclerView, eventHandler) => recyclerView.NotNull().ChildViewDetachedFromWindow += eventHandler,
                (recyclerView, eventHandler) => recyclerView.NotNull().ChildViewDetachedFromWindow -= eventHandler,
                (recyclerView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        recyclerView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (recyclerView, eventArgs) => null,
                () => "ChildViewDetachedFromWindow");
        }

        /// <summary>
        /// Binding on <see cref="RecyclerView.ScrollToPosition(int)"/> method.
        /// </summary>
        /// <param name="recyclerViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="RecyclerView.ScrollToPosition(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">recyclerViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<RecyclerView, int> ScrollToPositionBinding(
            [NotNull] this IItemReference<RecyclerView> recyclerViewReference)
        {
            if (recyclerViewReference == null)
                throw new ArgumentNullException(nameof(recyclerViewReference));

            return new TargetItemOneWayCustomBinding<RecyclerView, int>(
                recyclerViewReference,
                (recyclerView, position) => recyclerView.NotNull().ScrollToPosition(position),
                () => "ScrollToPosition");
        }

        /// <summary>
        /// Binding on <see cref="RecyclerView.SmoothScrollToPosition(int)"/> method.
        /// </summary>
        /// <param name="recyclerViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="RecyclerView.SmoothScrollToPosition(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">recyclerViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<RecyclerView, int> SmoothScrollToPositionBinding(
            [NotNull] this IItemReference<RecyclerView> recyclerViewReference)
        {
            if (recyclerViewReference == null)
                throw new ArgumentNullException(nameof(recyclerViewReference));

            return new TargetItemOneWayCustomBinding<RecyclerView, int>(
                recyclerViewReference,
                (recyclerView, position) => recyclerView.NotNull().SmoothScrollToPosition(position),
                () => "SmoothScrollToPosition");
        }
    }
}
