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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SelectedItemIdAndNavigationItemSelectedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            BottomNavigationView? bottomNavigationView,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(bottomNavigationView)
                .For(v => v.SelectedItemIdAndNavigationItemSelectedBinding(trackCanExecuteCommandChanged));
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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.ClickBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, object> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            Button? button,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(button)
                .For(v => v.ClickBinding(trackCanExecuteCommandChanged));
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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.CheckedAndCheckedChangeBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, bool> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            CheckBox? checkBox,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(checkBox)
                .For(v => v.CheckedAndCheckedChangeBinding(trackCanExecuteCommandChanged));
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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.TextAndTextChangedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefaultValue<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            EditText? editText,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(editText)
                .For(v => v.TextAndTextChangedBinding());
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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SetCheckedItemAndNavigationItemSelectedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            NavigationView? navigationView,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(navigationView)
                .For(v => v.SetCheckedItemAndNavigationItemSelectedBinding(trackCanExecuteCommandChanged));
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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.CheckAndCheckedChangeBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            RadioGroup? radioGroup,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(radioGroup)
                .For(v => v.CheckAndCheckedChangeBinding(trackCanExecuteCommandChanged));
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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SetQueryAndQueryTextChangeBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            SearchView? searchView,
            bool submit = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(searchView)
                .For(v => v.SetQueryAndQueryTextChangeBinding(submit, trackCanExecuteCommandChanged));
        }

        /// <summary>
        /// Two way binding on <see cref="AdapterView.SetSelection(int)"/> method and <see cref="AdapterView.ItemSelected"/> event. Item position is passed as a value.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set to which add the binding.</param>
        /// <param name="spinner">The spinner for which create the binding. Can be <c>null</c>.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AdapterView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SetSelectionAndItemSelectedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            Spinner? spinner,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(spinner)
                .For(v => v.SetSelectionAndItemSelectedBinding(trackCanExecuteCommandChanged));
        }

        /// <summary>
        /// One way binding on <see cref="TextView.Text"/> property.
        /// </summary>
        /// <typeparam name="TSourceItem">The type of the binding set source item.</typeparam>
        /// <param name="bindingSet">The binding set reference.</param>
        /// <param name="textView">The text view reference.</param>
        /// <returns>The binding builder instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bindingSet"/> is <c>null</c>.</exception>
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.TextBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, string> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            TextView? textView)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(textView)
                .For(v => v.TextBinding());
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
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.SetCurrentItemAndPageSelectedBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, int> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            ViewPager? viewPager,
            bool smoothScroll = true,
            bool trackCanExecuteCommandChanged = false)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(viewPager)
                .For(v => v.SetCurrentItemAndPageSelectedBinding(smoothScroll, trackCanExecuteCommandChanged));
        }
    }
}
