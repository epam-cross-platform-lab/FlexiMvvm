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
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class BindingSetExtensions
    {
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.TouchUpInsideBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, object> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UIButton button,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(button)
                .For(v => v.TouchUpInsideBinding(trackCanExecuteCommandChanged));
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.DateAndValueChangedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, NSDate> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UIDatePicker datePicker,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(datePicker)
                .For(v => v.DateAndValueChangedBinding(animated, trackCanExecuteCommandChanged));
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.TextBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UILabel label)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(label)
                .For(v => v.TextBinding());
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.TitleBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UINavigationItem navigationItem)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(navigationItem)
                .For(v => v.TitleBinding());
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.TextAndTextChangedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UISearchBar searchBar)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(searchBar)
                .For(v => v.TextAndTextChangedBinding());
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SelectedSegmentAndValueChangedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, nint> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UISegmentedControl segmentedControl,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(segmentedControl)
                .For(v => v.SelectedSegmentAndValueChangedBinding(trackCanExecuteCommandChanged));
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.TextAndEditingChangedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UITextField textField,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(textField)
                .For(v => v.TextAndEditingChangedBinding(trackCanExecuteCommandChanged));
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.ClickedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, object> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UIBarButtonItem barButtonItem,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(barButtonItem)
                .For(v => v.ClickedBinding(trackCanExecuteCommandChanged));
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SetStateAndValueChangedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, bool> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UISwitch @switch,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(@switch)
                .For(v => v.SetStateAndValueChangedBinding(animated, trackCanExecuteCommandChanged));
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.CurrentPageAndValueChangedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, nint> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UIPageControl pageControl,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(pageControl)
                .For(v => v.CurrentPageAndValueChangedBinding(trackCanExecuteCommandChanged));
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SetProgressBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, float> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            UIProgressView progressView,
            bool animated = true)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(progressView)
                .For(v => v.SetProgressBinding(animated));
        }
    }
}
