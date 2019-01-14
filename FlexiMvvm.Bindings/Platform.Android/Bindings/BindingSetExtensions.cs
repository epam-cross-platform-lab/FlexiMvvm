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
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Widget;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class BindingSetExtensions
    {
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, object> BindDefaultAction<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] Button button,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(button)
                .For(v => v.NotNull().ClickBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefaultValue<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] BottomNavigationView bottomNavigationView,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(bottomNavigationView)
                .For(v => v.NotNull().SelectedItemIdAndNavigationItemSelectedBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, bool> BindDefaultValue<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] CheckBox checkBox,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(checkBox)
                .For(v => v.NotNull().CheckedAndCheckedChangeBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefaultValue<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] EditText editText,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(editText)
                .For(v => v.NotNull().TextAndTextChangedBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefaultValue<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] RadioGroup radioGroup,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(radioGroup)
                .For(v => v.NotNull().CheckAndCheckedChangeBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefaultValue<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] SearchView searchView,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(searchView)
                .For(v => v.NotNull().QueryAndQueryTextChangeBinding(trackCanExecuteCommandChanged));
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefaultValue<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] TextView textView)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(textView)
                .For(v => v.NotNull().TextBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefaultValue<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] ViewPager viewPager)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(viewPager)
                .For(v => v.NotNull().SetCurrentItemAndPageSelectedBinding());
        }
    }
}
