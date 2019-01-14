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
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class BindingSetExtensions
    {
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, object> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UIButton button,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(button)
                .For(v => v.NotNull().TouchUpInsideBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, NSDate> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UIDatePicker datePicker,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(datePicker)
                .For(v => v.NotNull().DateAndValueChangedBinding(animated, trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UILabel label)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(label)
                .For(v => v.NotNull().TextBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UINavigationItem navigationItem)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(navigationItem)
                .For(v => v.NotNull().TitleBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UISearchBar searchBar)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(searchBar)
                .For(v => v.NotNull().TextAndTextChangedBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, nint> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UISegmentedControl segmentedControl,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(segmentedControl)
                .For(v => v.NotNull().SelectedSegmentAndValueChangedBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UITextField textField,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(textField)
                .For(v => v.NotNull().TextAndEditingChangedBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, object> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UIBarButtonItem barButtonItem,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(barButtonItem)
                .For(v => v.NotNull().ClickedBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, bool> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UISwitch @switch,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(@switch)
                .For(v => v.NotNull().SetStateAndValueChangedBinding(animated, trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, nint> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UIPageControl pageControl,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(pageControl)
                .For(v => v.NotNull().CurrentPageAndValueChangedBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, float> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UIProgressView progressView,
            bool animated = true)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(progressView)
                .For(v => v.NotNull().SetProgressBinding(animated));
        }
    }
}
