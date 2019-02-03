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
using System.Windows.Input;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Widget;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class BindingSetExtensions
    {
        /// <summary>
        /// Two way binding on <see cref="BottomNavigationView.SelectedItemId"/> property and <see cref="BottomNavigationView.NavigationItemSelected"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="bottomNavigationView">The bottom navigation view reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="BottomNavigationView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
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

        /// <summary>
        /// One way to source binding on <see cref="Button.Click"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="button">The button reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="Button.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, object> BindDefault<TSourceItem>(
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

        /// <summary>
        /// Two way binding on <see cref="CheckBox.Checked"/> property and <see cref="CheckBox.CheckedChange"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="checkBox">The check box reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="CheckBox.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, bool> BindDefault<TSourceItem>(
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

        /// <summary>
        /// Two way binding on <see cref="EditText.Text"/> property and <see cref="EditText.TextChanged"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="editText">The edit text reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="EditText.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
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

#if __ANDROID_28__
        /// <summary>
        /// Two way binding on <see cref="NavigationView.SetCheckedItem(int)"/> method and <see cref="NavigationView.NavigationItemSelected"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="navigationView">The navigation view reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="NavigationView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] NavigationView navigationView,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(navigationView)
                .For(v => v.NotNull().SetCheckedItemAndNavigationItemSelectedBinding(trackCanExecuteCommandChanged));
        }
#endif

        /// <summary>
        /// Two way binding on <see cref="RadioGroup.Check(int)"/> method and <see cref="RadioGroup.CheckedChange"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="radioGroup">The radio group reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="RadioGroup.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
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

        /// <summary>
        /// Two way binding on <see cref="SearchView.SetQuery(string, bool)"/> method and <see cref="SearchView.QueryTextChange"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="searchView">The search view reference.</param>
        /// <param name="submit">Second parameter of <see cref="SearchView.SetQuery(string, bool)"/> method.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="SearchView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] SearchView searchView,
            bool submit = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(searchView)
                .For(v => v.NotNull().SetQueryAndQueryTextChangeBinding(submit, trackCanExecuteCommandChanged));
        }

        /// <summary>
        /// One way binding on <see cref="TextView.Text"/> property.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="textView">The text view reference.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] TextView textView)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(textView)
                .For(v => v.NotNull().TextBinding());
        }

        /// <summary>
        /// Two way binding on <see cref="ViewPager.SetCurrentItem(int, bool)"/> method and <see cref="ViewPager.PageSelected"/> event.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="viewPager">The view pager reference.</param>
        /// <param name="smoothScroll">Second parameter of <see cref="ViewPager.SetCurrentItem(int, bool)"/> method.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="ViewPager.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] ViewPager viewPager,
            bool smoothScroll = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(viewPager)
                .For(v => v.NotNull().SetCurrentItemAndPageSelectedBinding(smoothScroll, trackCanExecuteCommandChanged));
        }
    }
}
